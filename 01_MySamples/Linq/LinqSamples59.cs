namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  /// Linq�ɂāA�V�[�P���X���`�����N�ɕ������ď�������T���v���ł�.
  /// </summary>
  public class LinqSamples59 : IExecutable
  {
    public void Execute()
    {
      //
      // �v�f��10�̃V�[�P���X��2���̃`�����N�ɕ���.
      //
      foreach (var chunk in Enumerable.Range(1, 10).Chunk(2))
      {
        Console.WriteLine("Chunk:");
        foreach (var item in chunk)
        {
          Console.WriteLine("\t--> {0}", item);
        }
      }

      //
      // �v�f��10000�̃V�[�P���X��1000���̃`�����N�ɕ�����
      // ���ꂼ��̃`�����N���ƂɃC���f�b�N�X��t�^.
      //
      foreach (var chunk in Enumerable.Range(1, 10000).Chunk(1000).Select((x, i) => new { Index = i, Count = x.Count() }))
      {
        Console.WriteLine(chunk);
      }
    }
  }
}
