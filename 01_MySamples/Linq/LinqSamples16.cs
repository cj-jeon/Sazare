namespace Gsf.Samples
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-16
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples16 : IExecutable
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
      // OfType���\�b�h�𗘗p���邱�Ƃɂ��A����̌^�݂̂̃V�[�P���X�ɕϊ����邱�Ƃ��ł���B
      // �Ⴆ�΁A���X�g�̒��Ɋ��N���X�ł���Person�N���X�Ɣh���N���X�ł���Customer�N���X��
      // �I�u�W�F�N�g�����݂��Ă���ꍇ�AOfType<Person>�Ƃ���ƁA���̂܂܁B
      // OfType<Customer>�Ƃ���ƁACustomer�I�u�W�F�N�g�݂̂̃V�[�P���X�ɕϊ������B
      //
      // ���AOfType���\�b�h�͑��̕ϊ����Z�q�Ƃ͈Ⴂ�A�\�[�X�V�[�P���X�̃X�i�b�v�V���b�g���쐬���Ȃ��B
      // �܂�A�ʏ�̃N�G���Ɠ������AOfType�Ŏ擾�����V�[�P���X���񋓂����x�ɕ]�������B
      // �ϊ����Z�q�̒��ŁA���̂悤�ȓ�����s���̂�AsEnumerable��OfType��Cast�ł���B
      //
      Console.WriteLine("========== OfType<Person>�̌��� ==========");
      foreach (var data in persons.OfType<Person>())
      {
        Console.WriteLine(data);
      }

      Console.WriteLine("========== OfType<Customer>�̌��� ==========");
      foreach (var data in persons.OfType<Customer>())
      {
        Console.WriteLine(data);
      }

      /*
        IEnumerable<Customer> c = persons.OfType<Customer>();
        persons.Add(new Customer { Id = 99, Name = "gsf_zero3", Orders = Enumerable.Empty<Order>() });
        
        foreach (var data in c)
        {
          Console.WriteLine(data);
        }
      */

      //
      // ���XGeneric�ł͂Ȃ����X�g��IEnumerable<T>�ɕϊ�����ꍇ�ɂ����p�o����.
      //
      ArrayList arrayList = new ArrayList();
      arrayList.Add(10);
      arrayList.Add(20);
      arrayList.Add(30);
      arrayList.Add(40);

      Console.WriteLine("========== Generic�ł͂Ȃ��R���N�V������ϊ� ==========");
      IEnumerable<int> intList = arrayList.OfType<int>();
      foreach (var data in intList)
      {
        Console.WriteLine(data);
      }
    }
  }
  #endregion
}
