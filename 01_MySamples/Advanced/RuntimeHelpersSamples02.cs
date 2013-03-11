namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Runtime.CompilerServices;
  using System.Runtime.ConstrainedExecution;

  #region RuntimeHelpersSamples-02
  /// <summary>
  /// RuntimeHelpersクラスのサンプルです。
  /// </summary>
  public class RuntimeHelpersSamples02 : IExecutable
  {
    // サンプルクラス
    static class SampleClass
    {
      static SampleClass()
      {
        Console.WriteLine("SampleClass static ctor()");
      }

      //
      // このメソッドに対して、CER内で利用できるよう信頼性のコントラクトを付与.
      // ReliabilityContractAttributeおよびConsistencyやCerは
      // System.Runtime.ConstrainedExecution名前空間に存在する.
      //
      // RuntimeHelpers.PrepareConstrainedRegionsメソッドにて
      // 実行できるのは、Consistency.WillNotCorruptStateおよびMayCorruptInstanceの場合のみ.
      //
      // 尚、この属性はメソッドだけではなく、クラスやインターフェースにも付与できる。
      // その場合、クラス全体に対して信頼性のコントラクトを付与したことになる。
      //
      [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      internal static void Print()
      {
        Console.WriteLine("SampleClass.Print()");
      }
    }

    public void Execute()
    {
      //
      // RuntimeHelpers.PrepareConstrainedRegionsを呼び出すと、コンパイラは
      // そのメソッド内のcatch, finallyブロックをCER（制約された実行領域）としてマークする。
      //
      // CERとしてマークされた領域から、コードを呼び出す場合、そのコードには信頼性のコントラクトが必要となる。
      // コードに対して、信頼性のコントラクトを付与するには、以下の属性を利用する。
      //  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
      //
      // CERでマークされた領域にて、コードに信頼性のコントラクトが付与されている場合、CLRは
      // try内の本処理が実行される前に、catch, finallyブロックのコードを事前コンパイルする。
      //
      // なので、例えばfinallyブロック内にて静的コンストラクタを持つクラスのメソッドを呼びだしていたり
      // すると、try内の本処理よりも先にfinallyブロック内の静的コンストラクタが呼ばれる事になる。
      // (事前コンパイルが行われると、アセンブリのロード、静的コンストラクタの実行などが発生するため)
      //
      RuntimeHelpers.PrepareConstrainedRegions();

      try
      {
        // 事前にRuntimeHelpers.PrepareConstrainedRegions()を呼び出している場合
        // 以下のメソッドが呼び出される前に、catch, finallyブロックが事前コンパイルされる.
        Calc();
      }
      finally
      {
        SampleClass.Print();
      }
    }

    void Calc()
    {
      for (int i = 0; i < 10; i++)
      {
        Console.Write("{0} ", (i + 1));
      }

      Console.WriteLine("");
    }
  }
  #endregion
}
