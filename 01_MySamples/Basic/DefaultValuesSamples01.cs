namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region DefaultValuesSamples-01
  /// <summary>
  /// �e�^�̃f�t�H���g�l�ɂ��ẴT���v���ł��B
  /// </summary>
  public class DefaultValuesSamples01 : IExecutable
  {
    class SampleClass { }
    struct SampleStruct { }

    public void Execute()
    {
      Console.WriteLine("byte   �̃f�t�H���g:    {0}", default(byte));
      Console.WriteLine("char   �̃f�t�H���g:    {0}", default(char) == 0x00);
      Console.WriteLine("short  �̃f�t�H���g:    {0}", default(short));
      Console.WriteLine("ushort �̃f�t�H���g:    {0}", default(ushort));
      Console.WriteLine("int  �̃f�t�H���g:    {0}", default(int));
      Console.WriteLine("uint   �̃f�t�H���g:    {0}", default(uint));
      Console.WriteLine("long   �̃f�t�H���g:    {0}", default(long));
      Console.WriteLine("ulong  �̃f�t�H���g:    {0}", default(ulong));
      Console.WriteLine("float  �̃f�t�H���g:    {0}", default(float));
      Console.WriteLine("double �̃f�t�H���g:    {0}", default(double));
      Console.WriteLine("decimal�̃f�t�H���g:    {0}", default(decimal));
      Console.WriteLine("string �̃f�t�H���g:    NULL = {0}", default(string) == null);
      Console.WriteLine("byte[] �̃f�t�H���g:    NULL = {0}", default(byte[]) == null);
      Console.WriteLine("List<string>�̃f�t�H���g: NULL = {0}", default(List<string>) == null);
      Console.WriteLine("���O�N���X�̃f�t�H���g:   NULL = {0}", default(SampleClass) == null);
      Console.WriteLine("���O�\���̂̃f�t�H���g:   {0}", default(SampleStruct));
    }
  }
  #endregion
}
