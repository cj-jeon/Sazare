namespace Gsf.Samples
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-17
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples17 : IExecutable
  {
    class Person
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }

    class Customer : Person
    {
      public IEnumerable<Order> Orders { get; set; }
    }

    class Order
    {
      public int Id { get; set; }
      public int Quantity { get; set; }
    }

    public void Execute()
    {
      List<Person> persons = new List<Person>
        {
           new Person { Id = 1, Name = "gsf_zero1" }
          ,new Person { Id = 2, Name = "gsf_zero2" }
          ,new Customer { Id = 3, Name = "gsf_zero3", Orders = Enumerable.Empty<Order>() }
          ,new Customer 
             { 
               Id = 4
              ,Name = "gsf_zero4"
              ,Orders =  new List<Order>
                 {
                    new Order { Id = 1, Quantity = 10 }
                   ,new Order { Id = 2, Quantity = 2  }
                 }
             }
          ,new Person { Id = 5, Name = "gsf_zero5" }
        };

      //
      // Cast���\�b�h�𗘗p���邱�Ƃɂ��A����̌^�݂̂̃V�[�P���X�ɕϊ����邱�Ƃ��ł���B
      // OfType���\�b�h�ƈႢ�ACast���\�b�h�͒P���ɃL���X�g�������s���ׁA�L���X�g�o���Ȃ��^��
      // �܂܂�Ă���ꍇ�͗�O����������B
      // (OfType���\�b�h�̏ꍇ�A���O�����B�j
      //
      //
      // ���ACast���\�b�h�͑��̕ϊ����Z�q�Ƃ͈Ⴂ�A�\�[�X�V�[�P���X�̃X�i�b�v�V���b�g���쐬���Ȃ��B
      // �܂�A�ʏ�̃N�G���Ɠ������ACast�Ŏ擾�����V�[�P���X���񋓂����x�ɕ]�������B
      // �ϊ����Z�q�̒��ŁA���̂悤�ȓ�����s���̂�AsEnumerable��OfType��Cast�ł���B
      //
      Console.WriteLine("========== Cast<Person>�̌��� ==========");
      foreach (var data in persons.Cast<Person>())
      {
        Console.WriteLine(data);
      }

      //////////////////////////////////////////////////////////
      //
      // �ȉ���persons.Cast<Customer>()��Person�I�u�W�F�N�g��Customer�I�u�W�F�N�g��
      // �L���X�g�o���Ȃ��ׁA��O����������B
      //
      Console.WriteLine("========== Cast<Customer>�̌��� ==========");
      try
      {
        foreach (var data in persons.Cast<Customer>())
        {
          Console.WriteLine(data);
        }
      }
      catch (InvalidCastException ex)
      {
        Console.WriteLine(ex.Message);
      }

      /*
        IEnumerable<Person> p = persons.Cast<Person>();
        persons.Add(new Person());
        
        Console.WriteLine("aaa");
        foreach (var a in p)
        {
          Console.WriteLine(a);
        }
      */

      //
      // ���XGeneric�ł͂Ȃ����X�g��IEnumerable<T>�ɕϊ�����ꍇ�ɂ����p�o����.
      // ���R�ACast���\�b�h�𗘗p����ꍇ�́A�R���N�V���������̃f�[�^���S�ăL���X�g�\��
      // �Ȃ��Ƃ����Ȃ��B
      //
      ArrayList arrayList = new ArrayList();
      arrayList.Add(10);
      arrayList.Add(20);
      arrayList.Add(30);
      arrayList.Add(40);

      Console.WriteLine("========== Generic�ł͂Ȃ��R���N�V������ϊ� ==========");
      IEnumerable<int> intList = arrayList.Cast<int>();
      foreach (var data in intList)
      {
        Console.WriteLine(data);
      }
    }
  }
  #endregion
}
