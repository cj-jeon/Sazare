namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region EqualityComparerSamples-01
  public class EqualityComparerSamples01 : IExecutable
  {
    public void Execute()
    {
      var d1 = new Data("data1", "data1-value1");
      var d2 = new Data("data2", "data2-value1");
      var d3 = new Data("data3", "data3-value1");

      // d1�Ɠ����l�����ʂ̃C���X�^���X���쐬���Ă���.
      var d1_2 = new Data(d1.Name, d1.Value);

      /////////////////////////////////////////////////////////
      //
      // object.Equals�Ŕ�r.
      //
      Console.WriteLine("===== object.Equals�Ŕ�r. =====");
      Console.WriteLine("d1.Equals(d2) : {0}", d1.Equals(d2));
      Console.WriteLine("d1.Equals(d3) : {0}", d1.Equals(d3));
      Console.WriteLine("d1.Equals(d1_2) : {0}", d1.Equals(d1_2));

      /////////////////////////////////////////////////////////
      //
      // EqualityComparer�Ŕ�r.
      //
      var comparer = new DataEqualityComparer();

      Console.WriteLine("===== EqualityComparer�Ŕ�r. =====");
      Console.WriteLine("d1.Equals(d2) : {0}", comparer.Equals(d1, d2));
      Console.WriteLine("d1.Equals(d3) : {0}", comparer.Equals(d1, d3));
      Console.WriteLine("d1.Equals(d1_2) : {0}", comparer.Equals(d1, d1_2));

      /////////////////////////////////////////////////////////
      //
      // Dictionary�ň�v���邩�ۂ����m�F (EqualityComparer����)
      //
      var dict1 = new Dictionary<Data, string>();

      dict1[d1] = d1.Value;
      dict1[d2] = d2.Value;
      dict1[d3] = d3.Value;

      // �ȉ��̃R�[�h�ł́A�����ƒl���擾�ł���. (�Q�Ƃ���������)
      Console.WriteLine("===== Dictionary�ň�v���邩�ۂ����m�F (EqualityComparer����). =====");
      Console.WriteLine("key:d1 ==> {0}", dict1[d1]);
      Console.WriteLine("key:d3 ==> {0}", dict1[d3]);

      // �ȉ��̃R�[�h�ł́A������true���擾�ł���. (�Q�Ƃ���������)
      Console.WriteLine("contains-key: d1 ==> {0}", dict1.ContainsKey(d1));
      Console.WriteLine("contains-key: d2 ==> {0}", dict1.ContainsKey(d2));
      Console.WriteLine("contains-key: d3 ==> {0}", dict1.ContainsKey(d3));

      //
      // �����l�����A�ʃC���X�^���X���쐬���AEqualityComparer�Ȃ���Dictionary�Ŏ����Ă݂�.
      //
      var d4 = new Data(d1.Name, d1.Value);
      var d5 = new Data(d2.Name, d2.Value);
      var d6 = new Data(d3.Name, d3.Value);

      // �ȉ��̃R�[�h�����s����Ɨ�O����������. (�L�[�Ƃ��Ĉ�v���Ȃ�����)
      try
      {
        Console.WriteLine("===== �����l�����A�ʃC���X�^���X���쐬���AEqualityComparer�Ȃ���Dictionary�Ŏ����Ă݂�. =====");
        Console.WriteLine("key:d4 ==> {0}", dict1[d4]);
      }
      catch (KeyNotFoundException)
      {
        Console.WriteLine("�L�[�Ƃ���d4���w�肵�܂������A��v����L�[��������܂���ł����B");
      }

      // ���R�AContainsKey���\�b�h��false��Ԃ�.
      Console.WriteLine("contains-key: d4 ==> {0}", dict1.ContainsKey(d4));


      /////////////////////////////////////////////////////////
      //
      // Dictionary���쐬����ۂɁAEqualityComparer���w�肵�č쐬.
      //
      var dict2 = new Dictionary<Data, string>(comparer);

      dict2[d1] = d1.Value;
      dict2[d2] = d2.Value;
      dict2[d3] = d3.Value;

      // �ȉ��̃R�[�h�ł́A�����ƒl���擾�ł���. (EqualityComparer���w�肵�Ă��邽��)
      Console.WriteLine("===== Dictionary���쐬����ۂɁAEqualityComparer���w�肵�č쐬. =====");
      Console.WriteLine("key:d4 ==> {0}", dict2[d4]);
      Console.WriteLine("key:d6 ==> {0}", dict2[d6]);

      // �ȉ��̃R�[�h�ł́A������true���擾�ł���. (EqualityComparer���w�肵�Ă��邽��)
      Console.WriteLine("contains-key: d4 ==> {0}", dict2.ContainsKey(d4));
      Console.WriteLine("contains-key: d5 ==> {0}", dict2.ContainsKey(d5));
      Console.WriteLine("contains-key: d6 ==> {0}", dict2.ContainsKey(d6));

      /////////////////////////////////////////////////////////
      //
      // EqualityComparer<T>�ɂ́ADefault�Ƃ����ÓI�v���p�e�B�����݂���.
      // ���̃v���p�e�B�́AT�Ɏw�肳�ꂽ�^��IEquatable<T>���������Ă��邩�ǂ�����
      // �`�F�b�N���A�������Ă���ꍇ�́A������IEquatable<T>�̎����𗘗p����
      // EqualityComaparer<T>���쐬���ĕԂ��Ă����.
      //
      // T�Ɏw�肳�ꂽ�^���AIEquatable<T>���������Ă��Ȃ��ꍇ
      // object.Equals, object.GetHashCode�𗘗p���������Ԃ�.
      //
      // �{�T���v���ŗ��p����T���v���N���X�́A�ȉ��̂悤�ɂȂ��Ă���.
      //   Data�N���X�F IEquatable<T>���������Ă��Ȃ�.
      //   Data2�N���X�F IEquatable<T>���������Ă���.
      //
      // ��L�̃N���X�ɑ΂��āA���ꂼ��EqualityComparer<T>.Default���Ăяo���ƈȉ���
      // �N���X�̃C���X�^���X���Ԃ��Ă���.
      //   Data�N���X�F  ObjectEqualityComparer`1
      //   Data2�N���X: GenericEqualityComparer`1
      // IEquatable<T>���������Ă���ꍇ�́AGenericEqualityComparer��
      // �������Ă��Ȃ��ꍇ�́AObjectEqualityComparer�ƂȂ�B
      //
      var dataEqualityComparer = EqualityComparer<Data>.Default;
      var data2EqualityComparer = EqualityComparer<Data2>.Default;

      // �������ꂽ�^��\��.
      Console.WriteLine("===== EqualityComparer<T>.Default�̓���. =====");
      Console.WriteLine("Data={0}, Data2={1}", dataEqualityComparer.GetType().Name, data2EqualityComparer.GetType().Name);

      // ���ꂼ��T���v���f�[�^���쐬���āA��r���Ă݂�.
      // ���A�ǂ���̏ꍇ��1�Ԗڂ̃f�[�^��3�Ԗڂ̃f�[�^�̃L�[�������ɂȂ�悤�ɂ��Ă���.
      var data_1 = new Data("data_1", "value_1");
      var data_2 = new Data("data_2", "value_2");
      var data_3 = new Data("data_1", "value_3");

      var data2_1 = new Data2("data2_1", "value2_1");
      var data2_2 = new Data2("data2_2", "value2_2");
      var data2_3 = new Data2("data2_1", "value2_3");

      // Data�N���X��EqualityComparer���g�p���Ĕ�r.
      Console.WriteLine("data_1.Equals(data_2) : {0}", dataEqualityComparer.Equals(data_1, data_2));
      Console.WriteLine("data_1.Equals(data_3) : {0}", dataEqualityComparer.Equals(data_1, data_3));

      // Data2�N���X��EqualityComparer���g�p���Ĕ�r.
      Console.WriteLine("data2_1.Equals(data2_2) : {0}", data2EqualityComparer.Equals(data2_1, data2_2));
      Console.WriteLine("data2_1.Equals(data2_3) : {0}", data2EqualityComparer.Equals(data2_1, data2_3));
    }

    class Data
    {
      public Data(string name, string value)
      {
        Name = name;
        Value = value;
      }

      public string Name
      {
        get;
        private set;
      }

      public string Value
      {
        get;
        private set;
      }

      public override string ToString()
      {
        return string.Format("Name={0}, Value={1}", Name, Value);
      }
    }

    class DataEqualityComparer : EqualityComparer<Data>
    {
      public override bool Equals(Data x, Data y)
      {
        if (x == null && y == null)
        {
          return true;
        }

        if (x == null || y == null)
        {
          return false;
        }

        return x.Name == y.Name;
      }

      public override int GetHashCode(Data x)
      {
        if (x == null || string.IsNullOrEmpty(x.Name))
        {
          return string.Empty.GetHashCode();
        }

        return x.Name.GetHashCode();
      }
    }

    class Data2 : IEquatable<Data2>
    {
      public Data2(string name, string value)
      {
        Name = name;
        Value = value;
      }

      public string Name
      {
        get;
        private set;
      }

      public string Value
      {
        get;
        private set;
      }

      public bool Equals(Data2 other)
      {
        if (other == null)
        {
          return false;
        }

        return other.Name == Name;
      }

      public override bool Equals(object other)
      {
        Data2 data = other as Data2;
        if (data == null)
        {
          return false;
        }

        return Equals(data);
      }

      public override int GetHashCode()
      {
        return string.IsNullOrEmpty(Name) ? string.Empty.GetHashCode() : Name.GetHashCode();
      }
    }
  }
  #endregion
}
