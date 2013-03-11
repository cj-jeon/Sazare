namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region DisposableSamples-01
  /// <summary>
  /// IDisposable�̃T���v���ł��B
  /// </summary>
  /// <remarks>
  /// �ȉ��̋L�������č쐬�����T���v���B
  ///   http://www.codeproject.com/Tips/458846/Using-using-Statements-DisposalAccumulator
  /// </remarks>
  public class DisposableSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // �ʏ�p�^�[��.
      //
      using (var disposable1 = new Disposable1())
      {
        using (var disposable2 = new Disposable2())
        {
          using (var disposable3 = new Disposable3())
          {
            Console.WriteLine("Dispose Start..");
          }
        }
      }

      //
      // �ʏ�p�^�[��: DisposableManager���p.
      //
      using (var manager = new DisposableManager())
      {
        var d1 = manager.Add(new Disposable1());
        var d2 = manager.Add(new Disposable2());
        var d3 = manager.Add(new Disposable3());

        Console.WriteLine("Dispose Start..");
      }

      //
      // ���������݂��A�쐬����Ȃ��I�u�W�F�N�g�����݂���\��������ꍇ.
      //
      Disposable1 dispose1 = null;
      Disposable2 dispose2 = null;
      Disposable3 dispose3 = null;

      bool isDispose2Create = false;
      try
      {
        dispose1 = new Disposable1();

        if (isDispose2Create)
        {
          dispose2 = new Disposable2();
        }

        dispose3 = new Disposable3();
      }
      finally
      {
        Console.WriteLine("Dispose Start..");
        DisposeIfNotNull(dispose1);
        DisposeIfNotNull(dispose2);
        DisposeIfNotNull(dispose3);
      }


      //
      // ��������: DisposableManager���p.
      //
      dispose1 = null;
      dispose2 = null;
      dispose3 = null;

      using (var manager = new DisposableManager())
      {
        dispose1 = manager.Add(new Disposable1());

        if (isDispose2Create)
        {
          dispose2 = manager.Add(new Disposable2());
        }

        dispose3 = manager.Add(new Disposable3());

        Console.WriteLine("Dispose Start..");
      }
    }

    void DisposeIfNotNull(IDisposable disposableObject)
    {
      if (disposableObject == null)
      {
        return;
      }

      disposableObject.Dispose();
    }

    class DisposableManager : IDisposable
    {
      Stack<IDisposable> _disposables;
      bool _isDisposed;

      public DisposableManager()
      {
        _disposables = new Stack<IDisposable>();
        _isDisposed = false;
      }

      public T Add<T>(T disposableObject) where T : IDisposable
      {
        Defence();

        if (disposableObject != null)
        {
          _disposables.Push(disposableObject);
        }

        return disposableObject;
      }

      public void Dispose()
      {
        _disposables.ToList().ForEach(disposable => disposable.Dispose());
        _disposables.Clear();

        _isDisposed = true;
      }

      void Defence()
      {
        if (_isDisposed)
        {
          throw new ObjectDisposedException("Cannot access a disposed object.");
        }
      }
    }

    class Base : IDisposable
    {
      public void Dispose()
      {
        Console.WriteLine("[{0}] Disposed...", GetType().Name);
      }
    }

    class Disposable1 : Base { }
    class Disposable2 : Base { }
    class Disposable3 : Base { }

  }
  #endregion
}
