namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;

  #region MarshalByRefObjectSamples-01
  /// <summary>
  /// MarshalByRefObject�N���X�Ɋւ���T���v���ł��B
  /// </summary>
  public class MarshalByRefObjectSamples01 : IExecutable
  {
    class CanNotMarshalByRef
    {
      public void PrintDomain()
      {
        Console.WriteLine("Object is executing in AppDomain \"{0}\"", AppDomain.CurrentDomain.FriendlyName);
      }
    }

    class CanMarshalByRef : MarshalByRefObject
    {
      public void PrintDomain()
      {
        Console.WriteLine("Object is executing in AppDomain \"{0}\"", AppDomain.CurrentDomain.FriendlyName);
      }
    }

    [Serializable]
    class CanSerialize
    {
      public void PrintDomain()
      {
        Console.WriteLine("Object is executing in AppDomain \"{0}\"", AppDomain.CurrentDomain.FriendlyName);
      }
    }

    public void Execute()
    {
      CanNotMarshalByRef obj1 = new CanNotMarshalByRef();
      obj1.PrintDomain();

      AppDomain newDomain = AppDomain.CreateDomain("new domain");

      /* ** ERROR **  "Gsf.Samples.MarshalByRefObjectSamples01+CanNotMarshalByRef"�̓V���A�����\�Ƃ��Đݒ肳��Ă��܂���B
      CanNotMarshalByRef obj2 = 
          (CanNotMarshalByRef) newDomain.CreateInstanceAndUnwrap(
              Assembly.GetExecutingAssembly().FullName, 
              typeof(CanNotMarshalByRef).FullName
          );

      obj2.PrintDomain();
      */

      CanMarshalByRef obj3 =
          (CanMarshalByRef)newDomain.CreateInstanceAndUnwrap(
              Assembly.GetExecutingAssembly().FullName,
              typeof(CanMarshalByRef).FullName
          );

      obj3.PrintDomain();

      //
      // Serializable������t�����������ł́A���s�͍s���邪�A�ʂ�AppDomain�������
      // ���s�ł͂Ȃ��āA�Ăь���AppDomain�ł̎��s�ƂȂ�B
      // (�܂�AAppDomain�̋��E���z���Ă��Ȃ��B)
      //
      CanSerialize obj4 =
          (CanSerialize)newDomain.CreateInstanceAndUnwrap(
              Assembly.GetExecutingAssembly().FullName,
              typeof(CanSerialize).FullName
          );

      obj4.PrintDomain();
    }
  }
  #endregion
}
