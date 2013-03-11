namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.ServiceModel;

  #region WcfSample-01
  /// <summary>
  /// WCF�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// �ł���{�I�ȃT�[�r�X�ƃN���C�A���g�̉������s���T���v���ł��B
  /// </remarks>
  public class WcfSamples01 : IExecutable
  {
    #region Constants
    /// <summary>
    /// �T�[�r�X��URL
    /// </summary>
    const string SERVICE_URL = "http://localhost:54321/HelloWorldService";
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
    public interface IHelloWorldService
    {
      /// <summary>
      /// �T�[�r�X���\�b�h
      /// </summary>
      [OperationContract]
      string SayHello();
    }

    /// <summary>
    /// �T�[�r�X�̎���
    /// </summary>
    public class HelloWorldService : IHelloWorldService
    {
      public string SayHello()
      {
        return "Hello World";
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
        using (ChannelFactory<IHelloWorldService> factory = CreateChannelFactory())
        {
          //
          // �N���C�A���g�v���L�V�I�u�W�F�N�g���擾.
          //
          IHelloWorldService proxy = factory.CreateChannel();

          //
          // �T�[�r�X���\�b�h���Ăяo���A���ʂ��擾.
          //
          Console.WriteLine("�T�[�r�X�̌Ăяo������= {0}", proxy.SayHello());
        }
      }
    }

    private ServiceHost CreateService()
    {
      //
      // �z�X�g��������
      //
      ServiceHost host = new ServiceHost(typeof(HelloWorldService), new Uri(SERVICE_URL));

      //
      // �G���h�|�C���g��ǉ�.
      //
      host.AddServiceEndpoint(typeof(IHelloWorldService), BINDING, ENDPOINT_ADDR);

      return host;
    }

    private ChannelFactory<IHelloWorldService> CreateChannelFactory()
    {
      //
      // �N���C�A���g������T�[�r�X�ɐڑ����邽�߂�ChannelFactory���\�z.
      //
      ChannelFactory<IHelloWorldService> factory =
        new ChannelFactory<IHelloWorldService>(BINDING, new EndpointAddress(SERVICE_URL));

      return factory;
    }
  }
  #endregion
}
