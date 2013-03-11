namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.Serialization;
  using System.ServiceModel;

  #region WcfSamples-03
  /// <summary>
  /// WCF�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// �����Ɩ߂�l�ɃJ�X�^���I�u�W�F�N�g���w�肷��T�[�r�X���\�b�h���`���Ă��܂��B
  /// </remarks>
  public class WcfSamples03 : IExecutable
  {
    #region Constants
    /// <summary>
    /// �T�[�r�X��URL
    /// </summary>
    const string SERVICE_URL = "http://localhost:54321/ReturnCustomDataService";
    /// <summary>
    /// �G���h�|�C���g��
    /// </summary>
    const string ENDPOINT_ADDR = "";
    /// <summary>
    /// �o�C���f�B���O
    /// </summary>
    readonly BasicHttpBinding BINDING = new BasicHttpBinding();
    #endregion

    /// <summary>
    /// �T�[�r�X�C���^�[�t�F�[�X
    /// </summary>
    [ServiceContract]
    public interface IReturnCustomDataService
    {
      [OperationContract]
      ReturnData Execute(Data data);
    }

    /// <summary>
    /// �T�[�r�X�����N���X
    /// </summary>
    public class ReturnCustomDataService : IReturnCustomDataService
    {
      public ReturnData Execute(Data data)
      {
        return new ReturnData { X = data.Y, Y = data.X };
      }
    }

    /// <summary>
    /// �T�[�r�X���\�b�h�̈����N���X
    /// </summary>
    [DataContract]
    public class Data
    {
      [DataMember]
      public int X
      {
        get;
        set;
      }

      [DataMember]
      public int Y
      {
        get;
        set;
      }

      public override string ToString()
      {
        return string.Format("X={0}, Y={1}", X, Y);
      }
    }

    /// <summary>
    /// �T�[�r�X���\�b�h�̖߂�l�N���X
    /// </summary>
    [DataContract]
    public class ReturnData
    {
      [DataMember]
      public int X
      {
        get;
        set;
      }

      [DataMember]
      public int Y
      {
        get;
        set;
      }

      public override string ToString()
      {
        return string.Format("X={0}, Y={1}", X, Y);
      }
    }

    public void Execute()
    {
      using (ServiceHost host = CreateService())
      {
        //
        // �T�[�r�X���J�n.
        //
        host.Open();

        //
        // �N���C�A���g�����\�z.
        //
        using (ChannelFactory<IReturnCustomDataService> factory = CreateChannelFactory())
        {
          //
          // �N���C�A���g�v���L�V�I�u�W�F�N�g���擾.
          //
          IReturnCustomDataService proxy = factory.CreateChannel();

          //
          // �T�[�r�X���\�b�h���Ăяo���A���ʂ��擾.
          //
          Data data = new Data { X = 300, Y = 200 };
          Console.WriteLine("�T�[�r�X�̌Ăяo���O= {0}", data);
          Console.WriteLine("�T�[�r�X�̌Ăяo������= {0}", proxy.Execute(data));
        }
      }
    }

    private ServiceHost CreateService()
    {
      //
      // �z�X�g��������
      //
      ServiceHost host = new ServiceHost(typeof(ReturnCustomDataService), new Uri(SERVICE_URL));

      //
      // �G���h�|�C���g��ǉ�.
      //
      host.AddServiceEndpoint(typeof(IReturnCustomDataService), BINDING, ENDPOINT_ADDR);

      return host;
    }

    private ChannelFactory<IReturnCustomDataService> CreateChannelFactory()
    {
      //
      // �N���C�A���g������T�[�r�X�ɐڑ����邽�߂�ChannelFactory���\�z.
      //
      ChannelFactory<IReturnCustomDataService> factory =
        new ChannelFactory<IReturnCustomDataService>(BINDING, new EndpointAddress(SERVICE_URL));

      return factory;
    }
  }
  #endregion
}
