namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-37
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples37 : IExecutable
  {
    class Order
    {
      public string Name { get; set; }
      public int Amount { get; set; }
      public int Month { get; set; }
    }

    public void Execute()
    {
      //
      // Aggregate�g�����\�b�h.
      //
      // Aggregate�g�����\�b�h�́A�w�肳�ꂽseed���N�_�l�Ƃ���func�֐����J��Ԃ��Ăяo��
      // ���ʂ��A�L�������[�^�[�ɕێ����Ă���郁�\�b�h�B
      //
      // python��map�֐��݂����Ȃ��̂ł���B
      //
      // Aggregate�́A�Ǝ��̏W�v�������s���ꍇ�ɗ��p����B
      // ���ASum, Min, Max, Average�g�����\�b�h�Ȃǂ�Aggregate�̓���ȃp�^�[���Ƃ�����B
      // (�܂�A�S��Aggregate�œ����悤�ɏ����ł���B�j
      //
      // ���p����ۂ̒��ӓ_�Ƃ��ẮAseed�𖾎��I�Ɏw�肵�Ȃ��ꍇ�A�ÖٓI��
      // �\�[�X�V�[�P���X�̍ŏ��̗v�f��seed�Ƃ��ė��p���ď������Ă���邱�Ƃł���B
      // �ʏ�̏ꍇ�͂���ŗǂ����A�o���邾��seed�͖����I�ɓn���������悢�B
      //

      //
      // Sum�g�����\�b�h�̓�����Aggregate�ōs��.
      //
      var query = Enumerable.Range(1, 10).Aggregate
              (
              0,        // seed
              (a, s) => a + s // func
              );

      Console.WriteLine("========= Sum�g�����\�b�h�̓��� ==========");
      Console.WriteLine("SUM = [{0}]", query);
      Console.WriteLine("======================================");

      //
      // �Ǝ��̏W�v�������s���Ă݂�.
      //   �ȉ��͊e�I�[�_�[�̔����ō��z�Ƃ��̌������߂�B
      //
      Console.WriteLine("========= �Ǝ��̏W�v�������s ==========");

      //
      // �\�[�X�V�[�P���X.
      //
      var orders = new Order[]
               {
                 new Order { Name = "gsf_zero1", Amount = 1000, Month = 3 },
                 new Order { Name = "gsf_zero1", Amount = 600, Month = 4 },
                 new Order { Name = "gsf_zero1", Amount = 100, Month = 5 },
                 new Order { Name = "gsf_zero2", Amount = 100, Month = 3 },
                 new Order { Name = "gsf_zero2", Amount = 1000, Month = 4 },
                 new Order { Name = "gsf_zero2", Amount = 1200, Month = 5 },
                 new Order { Name = "gsf_zero3", Amount = 1000, Month = 3 },
                 new Order { Name = "gsf_zero3", Amount = 1200, Month = 4 },
                 new Order { Name = "gsf_zero3", Amount = 900, Month = 5 },
               };

      //
      // �W�v����O�ɁA�I�[�_�[���P�ʂŃO���[�v��.
      //
      var orderGroupingQuery = from theOrder in orders
                               group theOrder by theOrder.Name;

      //
      // �ō������z�����߂�B
      //
      var maxOrderQuery = from orderGroup in orderGroupingQuery
                          select
                            new
                            {
                              Name = orderGroup.Key,
                              MaxOrder = orderGroup.Aggregate
                                     (
                                      new { MaxAmount = 0, Month = 0 },  // seed
                                      (a, s) => (a.MaxAmount > s.Amount) // func
                                            ? a
                                            : new { MaxAmount = s.Amount, Month = s.Month }
                                     )
                            };

      foreach (var item in maxOrderQuery)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine("======================================");
    }
  }
  #endregion
}
