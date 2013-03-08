namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Runtime.Serialization;
  using System.Runtime.Serialization.Formatters.Binary;

  #region SerializationSurrogateSamples-01
  /// <summary>
  /// �V���A���C�Y�Ɋւ���T���v���ł��B
  /// </summary>
  /// <remarks>
  /// �V���A�����T���Q�[�g�ɂ��āB (ISerializationSurrogate)
  /// </remarks>
  public class SerializationSurrogateSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // ���ʂ̃V���A���C�Y����.
      //
      var obj = MakeSerializableObject();
      using (var stream = new MemoryStream())
      {
        var formatter = new BinaryFormatter();

        // ��������.
        formatter.Serialize(stream, obj);

        stream.Position = 0;
        Console.WriteLine(formatter.Deserialize(stream));
      }

      //
      // �V���A���C�Y�s�� (Serializable���������Ă��Ȃ�)
      //
      var obj2 = MakeNotSerializableObject();
      using (var stream = new MemoryStream())
      {
        var formatter = new BinaryFormatter();

        try
        {
          // �ΏۃN���X��Serializable�������t�^����Ă��Ȃ��̂�
          // �ȉ������s����Ɨ�O����������.
          formatter.Serialize(stream, obj2);

          stream.Position = 0;
          Console.WriteLine(formatter.Deserialize(stream));
        }
        catch (SerializationException ex)
        {
          Console.WriteLine("[ERROR]: {0}", ex.Message);
        }
      }

      //
      // �V���A�����T���Q�[�g. (SerializationSurrogate)
      //
      var obj3 = MakeNotSerializableObject();
      using (var stream = new MemoryStream())
      {
        var formatter = new BinaryFormatter();

        //
        // �V���A�����T���Q�[�g���s�����߂ɁA�ȉ��̎菇�Őݒ���s��.
        //
        // 1.SurrogateSelector�I�u�W�F�N�g��p��.
        // 2.����Surrogate�N���X��p��.
        // 3.SurrogateSelector.AddSurrogate��Surrogate�I�u�W�F�N�g��ݒ�
        // 4.SurrogateSelector��Formatter�ɐݒ�.
        //
        // ����ɂ��A�V���A���C�Y�s�ȃI�u�W�F�N�g��Formatter�ɂăV���A���C�Y/�f�V���A���C�Y
        // ����ۂɃV���A�����T���Q�[�g���s����悤�ɂȂ�B
        //
        var selector = new SurrogateSelector();
        var surrogate = new CanNotSerializeSurrogate();
        var context = new StreamingContext(StreamingContextStates.All);

        selector.AddSurrogate(typeof(CanNotSerialize), context, surrogate);

        formatter.SurrogateSelector = selector;

        try
        {
          // �ʏ�A�ȉ������s����Ɨ�O���������邪
          // �V���A�����T���Q�[�g���s���̂ŁA�G���[�ƂȂ炸�V���A���C�Y����������.
          formatter.Serialize(stream, obj3);

          stream.Position = 0;
          Console.WriteLine(formatter.Deserialize(stream));
        }
        catch (SerializationException ex)
        {
          Console.WriteLine("[ERROR]: {0}", ex.Message);
        }
      }
    }

    IHasNameAndAge MakeSerializableObject()
    {
      return new CanSerialize
                 {
                   Name = "hoge"
                   ,
                   Age = 99
                 };
    }

    IHasNameAndAge MakeNotSerializableObject()
    {
      return new CanNotSerialize
                 {
                   Name = "hehe"
                    ,
                   Age = 98
                 };
    }

    #region SampleInterfaceAndClasses
    interface IHasNameAndAge
    {
      string Name { get; set; }
      int Age { get; set; }
    }

    // �V���A���C�Y�\�ȃN���X
    [Serializable]
    class CanSerialize : IHasNameAndAge
    {
      string _name;
      int _age;

      public string Name
      {
        get { return _name; }
        set { _name = value; }
      }

      public int Age
      {
        get { return _age; }
        set { _age = value; }
      }

      public override string ToString()
      {
        return string.Format("[CanSerialize] Name={0}, Age={1}", Name, Age);
      }
    }

    // �V���A���C�Y�s�ȃN���X
    class CanNotSerialize : IHasNameAndAge
    {
      string _name;
      int _age;

      public string Name
      {
        get { return _name; }
        set { _name = value; }
      }

      public int Age
      {
        get { return _age; }
        set { _age = value; }
      }

      public override string ToString()
      {
        return string.Format("[CanNotSerialize] Name={0}, Age={1}", Name, Age);
      }
    }

    // CanNotSerialize�N���X�̂��߂̃T���Q�[�g�N���X.
    class CanNotSerializeSurrogate : ISerializationSurrogate
    {
      // �V���A���C�Y���ɌĂяo����郁�\�b�h
      public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
      {
        CanNotSerialize targetObj = obj as CanNotSerialize;

        //
        // �V���A���C�Y���鍀�ڂƒl���ȉ��̂悤��info�ɐݒ肵�Ă���.
        //
        info.AddValue("Name", targetObj.Name);
        info.AddValue("Age", targetObj.Age);
      }

      // �f�V���A���C�Y���ɌĂяo����郁�\�b�h.
      public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
      {
        CanNotSerialize targetObj = obj as CanNotSerialize;

        //
        // info����l���擾���A�ΏۂƂȂ�I�u�W�F�N�g�ɐݒ�.
        //
        targetObj.Name = info.GetString("Name");
        targetObj.Age = info.GetInt32("Age");

        // Formatter��, ���̖߂�l�𖳎�����̂Ŗ߂�l��null�ŗǂ�.
        return null;
      }
    }
    #endregion
  }
  #endregion
}
