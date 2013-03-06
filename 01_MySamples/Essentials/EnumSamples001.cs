namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region EnumSamples-001
  /// <summary>
  /// Enum�ɂ��ẴT���v���ł��B
  /// </summary>
  public class EnumSamples001 : IExecutable
  {
    //
    // Enum���`.
    //
    // �t���O�l�Ƃ��Ă����p����ꍇ��FlagAttribute��t����.
    //
    // ��ɂȂ�^�͖����I�Ɏw�肵�Ȃ��ꍇ��int�ƂȂ�B
    // �񋓒萔�͂Q�̗ݏ�Œ�`������������͗l�B�iMSDN���j
    // 
    [Flags]
    private enum SampleEnum
    {
      Value1 = 1,
      Value2 = 2,
      Value3 = 4,
      Value4 = 16
    }

    public void Execute()
    {
      //
      // FlagsAttribute��t�^���Ă���ꍇ��
      // �P�̂̒l�Ƃ��Ă����p�ł��邪�AAND OR XOR��
      // ���Z���s����悤�ɂȂ�B
      // 
      SampleEnum enum1 = SampleEnum.Value2;
      SampleEnum enum2 = (SampleEnum.Value1 | SampleEnum.Value3);

      Console.WriteLine(enum1);
      Console.WriteLine(enum2);

      Console.WriteLine("enum2 has Value3? == {0}", ((enum2 & SampleEnum.Value3) == SampleEnum.Value3));
      Console.WriteLine("enum2 has Value2? == {0}", ((enum2 & SampleEnum.Value2) == SampleEnum.Value2));

      /////////////////////////////////////////////////////////////
      //
      // System.Enum�N���X�ɂ́A�񋓌^��������ŕ֗��ȃ��\�b�h��
      // �������p�ӂ���Ă���B
      //
      // ��Format���\�b�h
      // ��GetName���\�b�h
      // ��GetNames���\�b�h
      // ��GetUnderlyingType���\�b�h
      // ��GetValues���\�b�h
      // ��IsDefined���\�b�h
      // ��Parse���\�b�h
      // ��ToObject���\�b�h
      // ��ToString���\�b�h
      //
      Console.WriteLine(string.Empty);

      //
      // Format���\�b�h.
      //
      // �ΏۂƂȂ�񋓒l�����̃t�H�[�}�b�g�ɂ��Ď擾����B
      // �w��o����I�v�V�����͈ȉ��̒ʂ�B
      //
      // ��G or g: ���O���擾�i�A���A�l�����݂��Ȃ��ꍇ�A�P�O�i���ł��̒l���Ԃ����j
      // ��X or x: �P�U�i���Œl���擾 (�A���A0x�͐擪�ɕt�^����Ȃ��j
      // ��D or d: �P�O�i���Œl���擾
      // ��F or f: G�Ƃقړ����B
      //
      Console.WriteLine("============ {0} ============", "Format");
      Console.WriteLine(Enum.Format(typeof(SampleEnum), 2, "G"));
      Console.WriteLine(Enum.Format(typeof(SampleEnum), (2 | 3), "G"));
      Console.WriteLine(Enum.Format(typeof(SampleEnum), (SampleEnum.Value1 | SampleEnum.Value3), "G"));
      Console.WriteLine(Enum.Format(typeof(SampleEnum), SampleEnum.Value4, "X"));
      Console.WriteLine(Enum.Format(typeof(SampleEnum), SampleEnum.Value4, "D"));
      Console.WriteLine(Enum.Format(typeof(SampleEnum), SampleEnum.Value4, "F"));
      Console.WriteLine(Enum.Format(typeof(SampleEnum), (SampleEnum.Value1 | SampleEnum.Value4), "F"));

      //
      // GetName���\�b�h
      //
      // �ΏۂƂȂ�l����A�Ή�����񋓒l�̖��O���擾����.
      // �Ή�����񋓒l�����݂��Ȃ��ꍇ�́Anull�ƂȂ�B
      //
      Console.WriteLine("============ {0} ============", "GetName");
      int targetValue = 4;
      Console.WriteLine(Enum.GetName(typeof(SampleEnum), targetValue));
      Console.WriteLine(Enum.GetName(typeof(SampleEnum), -1) == null ? "null" : string.Empty);

      //
      // GetNames���\�b�h
      //
      // �ΏۂƂȂ�񋓌^�ɒ�`����Ă���l�̖��̂���C�Ɏ擾����.
      //
      Console.WriteLine("============ {0} ============", "GetNames");
      string[] names = Enum.GetNames(typeof(SampleEnum));
      names.ToList().ForEach(Console.WriteLine);

      //
      // GetUnderlyingType���\�b�h
      //
      // ����̗񋓒l��������񋓌^���擾����B
      //
      Console.WriteLine("============ {0} ============", "GetUnderlyingType");
      Enum enumVal = SampleEnum.Value2;
      Type enumType = enumVal.GetType();
      Type underlyingType = Enum.GetUnderlyingType(enumType);

      Console.WriteLine(enumType.Name);

      //
      // GetValues���\�b�h
      //
      // �ΏۂƂȂ�񋓌^�ɐݒ肳��Ă���l����C�Ɏ擾.
      //
      Console.WriteLine("============ {0} ============", "GetValues");
      Array valueArray = Enum.GetValues(typeof(SampleEnum));
      foreach (var element in valueArray)
      {
        Console.WriteLine(element);
      }

      //
      // IsDefined���\�b�h
      //
      // �w�肵���l���A�ΏۂƂȂ�񋓌^�ɑ��݂��邩�ۂ��𒲍�����B
      //
      Console.WriteLine("============ {0} ============", "IsDefined");
      Console.WriteLine("�l{0}��SampleEnum�ɑ��݂��邩�H {1}", 2, Enum.IsDefined(typeof(SampleEnum), 2));
      Console.WriteLine("�l{0}��SampleEnum�ɑ��݂��邩�H {1}", 10, Enum.IsDefined(typeof(SampleEnum), 10));

      //
      // Parse���\�b�h.
      //
      // �����񂩂�Ή�����񋓒l���擾����B
      // ���A�Y��������ɑΉ�����񋓒l�����݂��Ȃ��ꍇ��null�łȂ�
      // ArgumentException����������B
      //
      // Parse���\�b�h�ɂ́A�ȉ��̃p�^�[���̃f�[�^���w�肷�邱�Ƃ��o����B
      // ���P��̒l
      // ���񋓒l�̖��O
      // �����O���R���}�Ōq�������X�g
      //
      // ���O���R���}�Ōq�������X�g���w�肵���ꍇ�́A�Y������񋓒l��
      // OR���Z���ꂽ���ʂ��擾�ł���B
      //
      Console.WriteLine("============ {0} ============", "Parse");
      string testVal = "Value4";
      Console.WriteLine(Enum.Parse(typeof(SampleEnum), testVal));

      try
      {
        // ���݂��Ȃ��l���w��.
        Console.WriteLine(Enum.Parse(typeof(SampleEnum), "not_found"));
      }
      catch (ArgumentException)
      {
        Console.WriteLine("������ not_found �ɑΉ�����񋓒l�����݂��Ȃ��B");
      }

      testVal = "4";
      Console.WriteLine(Enum.Parse(typeof(SampleEnum), testVal));

      testVal = "Value1,Value2,Value4";
      Console.WriteLine(Enum.Parse(typeof(SampleEnum), testVal));

      //
      // ToObject���\�b�h.
      //
      // �w�肳�ꂽ�l��Ή�����񋓒l�ɕϊ�����B
      // �e�^�ɑΉ����邽�߂̃I�[�o�[���[�h���\�b�h�����݂���B
      //
      Console.WriteLine("============ {0} ============", "ToObject");
      int v = 1;
      Console.WriteLine(Enum.ToObject(typeof(SampleEnum), v));

      //
      // ToString���\�b�h.
      //
      // �Ή�����񋓒l�̕�����\�����擾����B
      // ����܂łɏ�q�����e�����͑S��Enum�N���X��static���\�b�h��
      // ���������A���̃��\�b�h�̓C���X�^���X���\�b�h�ƂȂ�B
      //
      // ��{�I�ɁAEnum.Format���\�b�h��"G"��K�p�������ʂƂȂ�B
      // �iIFormatProvider���w�肵���ꍇ�̓J�X�^�������ƂȂ�B�j
      //
      Console.WriteLine("============ {0} ============", "ToString");
      SampleEnum e1 = SampleEnum.Value4;
      Console.WriteLine(e1.ToString());

    }
  }
  #endregion
}
