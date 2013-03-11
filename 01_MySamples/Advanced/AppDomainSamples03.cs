namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;

  #region AppDomainSamples-03
  /// <summary>
  /// AppDomain�N���X�̃T���v���ł��B
  /// </summary>
  public class AppDomainSamples03 : IExecutable
  {
    // AppDomain�̃��j�^�����O��S������N���X
    class AppDomainMonitor : IDisposable
    {
      static AppDomainMonitor()
      {
        //
        // AppDomain.MonitoringIsEnabled�́A����ȃv���p�e�B��
        // �ȉ��̓��������B
        //
        // �E��xTrue�i�Ď�ON�j�ɂ�����Afalse�i�Ď�OFF�j�ɖ߂����Ƃ͂ł��Ȃ��B
        // �E�l��True,False�֌W�Ȃ��AFalse��ݒ肵�悤�Ƃ���Ɨ�O����������B
        // �E�ݒ�́AAppDomain���ʐݒ�ƂȂ�A�����AppDomain�݂̂̊Ď��͍s���Ȃ�.
        //
        if (!AppDomain.MonitoringIsEnabled)
        {
          AppDomain.MonitoringIsEnabled = true;
        }
      }

      public void Dispose()
      {
        // �t���u���b�L���O�R���N�V���������s.
        GC.Collect();
        PrintMonitoringValues(AppDomain.CurrentDomain);
      }

      public void PrintMonitoringValues(AppDomain domain)
      {
        //
        // ���j�^�����O��ON�ɂ���ƁA�ȉ��̃v���p�e�B�ɃA�N�Z�X���ē��v�����擾���邱�Ƃ��ł���悤�ɂȂ�B
        //
        // �EMonitoringSurvivedMemorySize
        //    �Ō�̊��S�ȃu���b�L���O �R���N�V�����̎��s��Ɏc���ꂽ�A���݂̃A�v���P�[�V���� �h���C���ɂ���ĎQ�Ƃ���Ă��邱�Ƃ��������Ă���o�C�g��
        // �EMonitoringSurvivedProcessMemorySize
        //    �Ō�̊��S�ȃu���b�L���O �R���N�V�����̎��s��Ɏc���ꂽ�A�v���Z�X���̂��ׂẴA�v���P�[�V���� �h���C���ɂ����鍇�v�o�C�g��
        // �EMonitoringTotalAllocatedMemorySize
        //    �A�v���P�[�V���� �h���C�����쐬����Ă���A���̃A�v���P�[�V���� �h���C���Ŏ��s���ꂽ���ׂẴ��������蓖�Ă̍��v�T�C�Y�i�o�C�g�P�ʁj
        //    ���W���ꂽ�������͍���������Ȃ��B
        // �EMonitoringTotalProcessorTime
        //    �v���Z�X���J�n����Ă���A���݂̃A�v���P�[�V���� �h���C���ł̎��s���ɂ��ׂẴX���b�h�Ŏg�p���ꂽ���v�v���Z�b�T����
        //
        // ���S�ȃu���b�L���O�R���N�V�����i�t���u���b�L���O�R���N�V�����j�́AGC.Collect���\�b�h�Ŏ��s�ł���B
        //
        Console.WriteLine("============================================");
        Console.WriteLine("MonitoringSurvivedMemorySize        = {0:N0}", domain.MonitoringSurvivedMemorySize);
        Console.WriteLine("MonitoringSurvivedProcessMemorySize = {0:N0}", AppDomain.MonitoringSurvivedProcessMemorySize);
        Console.WriteLine("MonitoringTotalAllocatedMemorySize  = {0:N0}", domain.MonitoringTotalAllocatedMemorySize);
        Console.WriteLine("MonitoringTotalProcessorTime        = {0}", domain.MonitoringTotalProcessorTime);
        Console.WriteLine("============================================");
      }
    }

    public void Execute()
    {
      using (AppDomainMonitor monitor = new AppDomainMonitor())
      {
        monitor.PrintMonitoringValues(AppDomain.CurrentDomain);

        List<string> aList = new List<string>();
        for (int i = 0; i < 1000; i++)
        {
          aList.Add(string.Format("hello world-{0:D2}", i));
        }

        monitor.PrintMonitoringValues(AppDomain.CurrentDomain);

        // CPU�^�C����\���������̂ŁA�����X�s��.
        Thread.SpinWait(700000000);
      }
    }
  }
  #endregion
}
