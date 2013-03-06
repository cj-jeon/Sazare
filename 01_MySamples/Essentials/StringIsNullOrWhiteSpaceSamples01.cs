namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region String::IsNullOrWhiteSpace���\�b�h�̃T���v��
  /// <summary>
  /// String.IsNullOrWhiteSpace���\�b�h�ɂ��ẴT���v���ł��B
  /// </summary>
  /// <remarks>
  /// .NET 4.0����ǉ����ꂽ���\�b�h�ł��B
  /// </remarks>
  public class StringIsNullOrWhiteSpaceSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // String::IsNullOrWhiteSpace���\�b�h�́AIsNullOrEmpty���\�b�h�̓����
      // �����A�X�ɋ󔒕����݂̂̏ꍇ���`�F�b�N���Ă����B
      //
      string nullStr = null;
      string emptyStr = string.Empty;
      string spaceStr = "    ";
      string normalStr = "hello world";
      string zenkakuSpaceStr = "�@�@�@";

      //
      // String::IsNullOrEmpty�ł̌���.
      //
      Console.WriteLine("============= String::IsNullOrEmpty ==============");
      Console.WriteLine("nullStr   = {0}", string.IsNullOrEmpty(nullStr));
      Console.WriteLine("emptyStr  = {0}", string.IsNullOrEmpty(emptyStr));
      Console.WriteLine("spaceStr  = {0}", string.IsNullOrEmpty(spaceStr));
      Console.WriteLine("normalStr = {0}", string.IsNullOrEmpty(normalStr));
      Console.WriteLine("zenkakuSpaceStr = {0}", string.IsNullOrEmpty(zenkakuSpaceStr));

      //
      // String::IsNullOrWhiteSpace�ł̌���.
      //  �S�p�󔒂��X�y�[�X�ƌ��Ȃ����_�ɒ��ӁB
      //
      Console.WriteLine("============= String::IsNullOrWhiteSpace ==============");
      Console.WriteLine("nullStr   = {0}", string.IsNullOrWhiteSpace(nullStr));
      Console.WriteLine("emptyStr  = {0}", string.IsNullOrWhiteSpace(emptyStr));
      Console.WriteLine("spaceStr  = {0}", string.IsNullOrWhiteSpace(spaceStr));
      Console.WriteLine("normalStr = {0}", string.IsNullOrWhiteSpace(normalStr));
      Console.WriteLine("zenkakuSpaceStr = {0}", string.IsNullOrWhiteSpace(zenkakuSpaceStr));
    }
  }
  #endregion
}
