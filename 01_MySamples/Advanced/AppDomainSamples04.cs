namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region AppDomainSamples-04
  public class AppDomainSamples04 : MarshalByRefObject, IExecutable
  {
    public void Execute()
    {
      //
      // AppDomain�𗘗p���āA�ʂ�AppDomain�ŏ��������s���邽�߂̕��@�́A���������݂���B
      //
      // �EAppDomain.ExecuteAssembly�𗘗p����B
      // �EAppDomain.DoCallback�𗘗p����B
      // �EAppDomain.CreateInstanceAndUnwrap�𗘗p���āA�v���L�V���擾�����s.
      //
      var currentDomain = AppDomain.CurrentDomain;
      var anotherDomain = AppDomain.CreateDomain("AD No.2");

      //
      // AppDomain.ExecuteAssembly�𗘗p���Ď��s.
      // 
      // ExecuteAssembly���\�b�h�ɂ́A�A�Z���u�������w�肷��B
      // �����Ŏw�肷��A�Z���u���͎��s�\�ł���K�v������A�G���g���|�C���g�������Ă���K�v������B
      //
      anotherDomain.ExecuteAssembly(@"AnotherAppDomain.exe");

      //
      // AppDomain.DoCallback�𗘗p����.
      //
      // DoCallback�͎w�肳�ꂽ�f���Q�[�g�����s���邽�߂̃��\�b�h.
      // �ʂ�AppDomain��DoCallback�Ƀf���Q�[�g��n�����ɂ��
      // ���������̃A�v���P�[�V�����h���C���Ŏ��s�����B
      //
      // ���R�A�l�n��(Serializable)�ƎQ�Ɠn��(MarshalByRefObject)�ɂ���Ď��s���ʂ��قȂ�ꍇ������.
      //
      // Static���\�b�h
      Console.WriteLine("----------[Static Method]--------");
      currentDomain.DoCallBack(CallbackMethod_S);
      anotherDomain.DoCallBack(CallbackMethod_S);
      Console.WriteLine("---------------------------------");

      // �C���X�^���X���\�b�h.
      Console.WriteLine("---------[Instance Method]-------");
      currentDomain.DoCallBack(CallbackMethod);
      anotherDomain.DoCallBack(CallbackMethod);
      Console.WriteLine("---------------------------------");

      // �l�n�� (Serializable)
      var byvalObj = new MarshalByVal();

      Console.WriteLine("---------[Serializable]----------");
      currentDomain.DoCallBack(byvalObj.CallbackMethod);
      anotherDomain.DoCallBack(byvalObj.CallbackMethod);
      Console.WriteLine("---------------------------------");

      // �Q�Ɠn�� (MarshalByRefObject)
      // MarshalByRefObject���p�����Ă��邽�߁A�ȉ��̗�ł͕K���f�t�H���g�h���C���Ŏ��s����邱�ƂɂȂ�B
      var byrefObj = new MarshalByRef();

      Console.WriteLine("-------[MarshalByRefObject]------");
      currentDomain.DoCallBack(byrefObj.CallbackMethod);
      anotherDomain.DoCallBack(byrefObj.CallbackMethod);
      Console.WriteLine("---------------------------------");

      //
      // AppDomain.CreateInstanceAndUnwrap�𗘗p����B
      // �v���L�V���擾���ď��������s����.
      //
      var asmName = typeof(MarshalByRef).Assembly.FullName;
      var typeName = typeof(MarshalByRef).FullName;

      var obj = (MarshalByRef)anotherDomain.CreateInstanceAndUnwrap(asmName, typeName);

      Console.WriteLine("-------[CreateInstanceAndUnwrap]------");
      obj.CallbackMethod();
      Console.WriteLine("--------------------------------------");

      AppDomain.Unload(anotherDomain);
    }

    static void CallbackMethod_S()
    {
      Utils.PrintAsmName();
    }

    void CallbackMethod()
    {
      Utils.PrintAsmName();
    }

    [Serializable]
    public class MarshalByVal
    {
      public void CallbackMethod()
      {
        Utils.PrintAsmName();
      }
    }

    public class MarshalByRef : MarshalByRefObject
    {
      public void CallbackMethod()
      {
        Utils.PrintAsmName();
      }
    }

    static class Utils
    {
      public static void PrintAsmName()
      {
        var domain = AppDomain.CurrentDomain.FriendlyName;
        Console.WriteLine("Run on AppDomain:{0}", domain);
      }
    }
  }
  #endregion
}
