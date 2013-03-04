namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  #region LinqSamples-21
  /// <summary>
  /// Linq�̃T���v���ł��B
  /// </summary>
  public class LinqSamples21 : IExecutable
  {
    class Team
    {
      public string Name { get; set; }
      public IEnumerable<string> Members { get; set; }
    }

    public void Execute()
    {
      var teams = new List<Team>
              {
                new Team { Name = "Team A", Members = new List<string>{ "gsf_zero1", "gsf_zero2" } },
                new Team { Name = "Team B", Members = new List<string>{ "gsf_zero3", "gsf_zero4" } }
              };

      //
      // SelectMany�g�����\�b�h�́A�R���N�V�����𕽒R������ۂɗ��p�ł���B
      // �Ⴆ�΁A��L�ō쐬����teams�ϐ��͈ȉ��̂悤�ȍ\���ɂȂ��Ă���B
      //
      //   teams -- [0]:Team�I�u�W�F�N�g
      //            ��Members:IEnumerable<string>
      //        [1]:Team�I�u�W�F�N�g
      //            ��Members:IEnumerable<string>
      //
      // �eTeam�I�u�W�F�N�g�́AMembers�v���p�e�B�������Ă���̂�
      // SelectMany�ł͂Ȃ��ASelect�g�����\�b�h�𗘗p����
      //  teams.Select(team => team.Members)
      // �Ƃ���ƁA���ʂ́AIEnumerable<IEnumerable<string>>�ƂȂ�B
      //
      // ���̂悤�ȏ�ԂŁASelectMany�g�����\�b�h�𗘗p����
      //  teams.SelectMany(team => team.Members)
      // �Ƃ���ƁA���ʂ́AIEnumerable<string>�ƂȂ�B
      // �܂�ASelectMany�g�����\�b�h�́A�eSelector���Ԃ��V�[�P���X���ŏI�I��
      // ���R�����Ă��猋�ʂ�Ԃ��Ă����B
      //
      // ���ASelectMany�g�����\�b�h�́A�N�G�����ɂ�2�i�ȏ��from��𗘗p���Ă���ꍇ
      // �ÖٓI�ɗ��p����Ă���B��L��teams.SelectMany(team => team.Members)��
      // �ȉ��̃N�G�����Ɠ����ł���B
      //
      //   from   team   in teams
      //   from   member in team.Members
      //   select member
      //
      // ���s���ɂ́A�Ō��select�̕�����SelectMany�ɒu�������B
      //
      Console.WriteLine("===== Func<TSource, IEnumerable<TResult>>�̃T���v�� =====");
      foreach (var member in teams.SelectMany(team => team.Members))
      {
        Console.WriteLine(member);
      }

      Console.WriteLine("===== Func<TSource, int, IEnumerable<TResult>>�̃T���v�� =====");
      foreach (var member in teams.SelectMany((team, index) => (index % 2 == 0) ? team.Members : new List<string>()))
      {
        Console.WriteLine(member);
      }

      Console.WriteLine("===== collectionSelector��resultSelector�𗘗p���Ă���T���v�� (1) =====");
      var query = teams.SelectMany
            (
              team => team.Members,                     // collectionSelector
              (team, member) => new { Team = team.Name, Name = member }   // resultSelector
            );

      foreach (var item in query)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("===== collectionSelector��resultSelector�𗘗p���Ă���T���v�� (2) =====");
      var query2 = teams.SelectMany
             (
               (team, index) => (index % 2 != 0) ? team.Members : new List<string>(),  // collectionSelector
               (team, member) => new { Team = team.Name, Name = member }        // resultSelector
             );

      foreach (var item in query2)
      {
        Console.WriteLine(item);
      }
    }
  }
  #endregion
}
