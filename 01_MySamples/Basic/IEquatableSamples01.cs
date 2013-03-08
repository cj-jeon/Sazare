namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region IEquatableSamples-01
  /// <summary>
  /// IEquatable<T>�̃T���v���ł��B
  /// </summary> -->
  public class IEquatableSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // IEquatable<T>�C���^�[�t�F�[�X�́A2�̃C���X�^���X�����������ۂ��𔻕ʂ��邽�߂�
      // �^�w���Equals���\�b�h���`���Ă���C���^�[�t�F�[�X�ł���B
      //
      // ���̃C���^�[�t�F�[�X���������邱�ƂŁA�ʏ��object.Equals�ȊO�Ɍ^���w�肳�ꂽ
      // Equals���\�b�h�������Ƃ��ł���悤�ɂȂ�B
      // ���̃C���^�[�t�F�[�X�́A���ɍ\���̂��`�����ŏd�v�ł���A�\���̂̏ꍇ�Aobject.Equals��
      // ��r���s���ƁA�{�b�N�X�����������Ă��܂����߁AIEquatable<T>���������邱�Ƃ������B
      // (�{�b�N�X�����������Ȃ��Ȃ邽�߁B�j
      //
      // �܂��A�����ɂ͕K�{�ł͂Ȃ����AIEquatable<T>����������ꍇ�A�����Ɉȉ��̃��\�b�h���I�[�o�[���C�h����̂����ʂł���B
      //   �Eobject.Equals
      //   �Eobject.GetHashCode
      // object.Equals���I�[�o�[���C�h����̂́AIEquatable���������Ă��Ă��N���X�ɂ���ẮA����𖳎����ċ����I��object.Equals��
      // ��r���鏈�������݂��邽�߂ł���B
      //
      // IEquatable<T>�C���^�[�t�F�[�X�́ADictionary<TKey, TValue>, List<T>�Ȃǂ̃W�F�l���b�N�R���N�V�����ɂ�
      // Contains, IndexOf, LastIndexOf, Remove�Ȃǂ̊e���\�b�h�œ��������e�X�g����ꍇ�ɗ��p�����B
      // (Array��IndexOf���\�b�h�Ȃǂł����l�ɗ��p�����B)
      // �����C���^�[�t�F�[�X�ŁA��r�@�\��񋟂�����̂Ƃ��āAIComparable<T>�C���^�[�t�F�[�X������B
      //
      // object.GetHashCode���I�[�o�[���C�h����̂́A��̗��R�ɂ��object.Equals���I�[�o�[���C�h����邽�߁B
      //
      Data data1 = new Data(1, "Hello World");
      Data data2 = new Data(2, "Hello World2");
      Data data3 = new Data(3, "Hello World3");
      Data data4 = data3;
      Data data5 = new Data(1, "Hello World4");

      Console.WriteLine("data1 equals data2? ==> {0}", data1.Equals(data2));
      Console.WriteLine("data1 equals data3? ==> {0}", data1.Equals(data3));
      Console.WriteLine("data1 equals data4? ==> {0}", data1.Equals(data4));
      Console.WriteLine("data1 equals data5? ==> {0}", data1.Equals(data5));

      object d1 = data1;
      object d2 = data2;
      object d5 = data5;

      Console.WriteLine("data1 equals data2? ==> {0}", d1.Equals(d2));
      Console.WriteLine("data1 equals data5? ==> {0}", d1.Equals(d5));

      Data[] dataArray = { data1, data2, data3, data4, data5 };
      Console.WriteLine("IndexOf={0}", Array.IndexOf(dataArray, data3));
    }

    sealed class Data : IEquatable<Data>
    {
      public Data(int id, string name)
      {
        Id = id;
        Name = name;
      }

      public int Id
      {
        get;
        private set;
      }

      public string Name
      {
        get;
        private set;
      }

      // IEquatable<T>�̎���.
      public bool Equals(Data other)
      {
        Console.WriteLine("\t����Call IEquatable.Equals");

        if (other == null)
        {
          return false;
        }

        return Id == other.Id;
      }

      // object.Equals
      public override bool Equals(object other)
      {
        Console.WriteLine("\t����Call object.Equals");

        Data data = other as Data;
        if (data == null)
        {
          return false;
        }

        return Equals(data);
      }

      // object.GetHashCode
      public override int GetHashCode()
      {
        return Id.GetHashCode();
      }
    }
  }
  #endregion
}
