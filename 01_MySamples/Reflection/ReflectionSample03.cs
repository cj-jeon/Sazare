namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Reflection;

  #region ReflectionSample-03
  /// <summary>
  /// ���t���N�V�����̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// ���t���N�V�������s���̃p�t�H�[�}���X���A�b�v��������@�ɂ��ċL�q���Ă��܂��B
  /// </remarks>
  public class ReflectionSample03 : IExecutable
  {
    delegate string StringToString(string s);

    public void Execute()
    {
      //
      // ���t���N�V�����𗘗p���ď��������s����ꍇ
      // ���̂܂�MethodInfo��Invoke���Ă�ł��ǂ���
      // ���x���ĂԕK�v������ꍇ�A�ȉ��̂悤�Ɉ�Udelegate��
      // ���Ă�����s��������A�p�t�H�[�}���X���ǂ��B
      //
      // MethodInfo.Invoke�𒼐ڌĂԃp�^�[���ł́A���񃌃C�g�o�C���f�B���O
      // ���������Ă��邪�Adelegate�ɂ��Ă���Ăԃp�^�[���ł�
      // delegate���\�z���Ă���ŏ��̈��̂݃��C�g�o�C���f�B���O����邩��ł���B
      //
      // ���A���R��ԑ����͖̂{���̃��\�b�h�𒼐ڌĂԃp�^�[���B
      //

      //
      // MethodInfo.Invoke�𗘗p����p�^�[��.
      //
      MethodInfo mi = typeof(string).GetMethod("Trim", new Type[0]);

      Stopwatch watch = Stopwatch.StartNew();
      for (int i = 0; i < 3000000; i++)
      {
        string result = mi.Invoke("test", null) as string;
      }
      watch.Stop();

      Console.WriteLine("MethodInfo.Invoke�𒼐ڌĂ�: {0}", watch.Elapsed);

      //
      // Delegate���\�z���ČĂԃp�^�[��.
      //
      StringToString s2s = (StringToString)Delegate.CreateDelegate(typeof(StringToString), mi);
      watch.Reset();
      watch.Start();
      for (int i = 0; i < 3000000; i++)
      {
        string result = s2s("test");
      }
      watch.Stop();

      Console.WriteLine("Delegate���\�z���ď���: {0}", watch.Elapsed);

      //
      // �{���̃��\�b�h�𒼐ڌĂԃp�^�[��.
      //
      watch.Reset();
      watch.Start();
      for (int i = 0; i < 3000000; i++)
      {
        string result = "test".Trim();
      }
      watch.Stop();

      Console.WriteLine("string.Trim�𒼐ڌĂ�: {0}", watch.Elapsed);
    }
  }
  #endregion
}
