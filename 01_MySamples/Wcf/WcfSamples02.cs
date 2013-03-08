namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.Serialization;
  using System.ServiceModel;

  #region WcfSamples-02
  /// <summary>
  /// WCF�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// �����ɃJ�X�^���I�u�W�F�N�g���w�肷��T�[�r�X���\�b�h���`���Ă��܂��B
  /// </remarks>
  public class WcfSamples02 : IExecutable
  {
    #region Constants
    /// <summary>
    /// �T�[�r�X��URL
    /// </summary>
    const string SERVICE_URL = "http://localhost:54321/NumberSumService";
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
    public interface INumberSumService
    {
      /// <summary>
      /// �T�[�r�X���\�b�h
      /// </summary>
      [OperationContract]
      int Sum(Data data);
    }

    /// <summary>
    /// �T�[�r�X�̎����N���X
    /// </summary>
    public class NumberSumService : INumberSumService
    {
      public int Sum(Data data)
      {
        return (data.X + data.Y);
      }
    }

    /// <summary>
    /// �f�[�^�R���g���N�g�N���X
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
        using (ChannelFactory<INumberSumService> factory = CreateChannelFactory())
        {
          //
          // �N���C�A���g�v���L�V�I�u�W�F�N�g���擾.
          //
          INumberSumService proxy = factory.CreateChannel();

          //
          // �T�[�r�X���\�b�h���Ăяo���A���ʂ��擾.
          //
          Console.WriteLine("�T�[�r�X�̌Ăяo������= {0}", proxy.Sum(new Data { X = 300, Y = 200 }));
        }
      }
    }

    private ServiceHost CreateService()
    {
      //
      // �z�X�g��������
      //
      ServiceHost host = new ServiceHost(typeof(NumberSumService), new Uri(SERVICE_URL));

      //
      // �G���h�|�C���g��ǉ�.
      //
      host.AddServiceEndpoint(typeof(INumberSumService), BINDING, ENDPOINT_ADDR);

      return host;
    }

    private ChannelFactory<INumberSumService> CreateChannelFactory()
    {
      //
      // �N���C�A���g������T�[�r�X�ɐڑ����邽�߂�ChannelFactory���\�z.
      //
      ChannelFactory<INumberSumService> factory =
        new ChannelFactory<INumberSumService>(BINDING, new EndpointAddress(SERVICE_URL));

      return factory;
    }
  }
  #endregion
}
