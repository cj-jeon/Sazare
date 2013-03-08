namespace Gsf.Samples
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Drawing;
  using System.Linq;

  using GDIImage = System.Drawing.Image;

  #region ImageConverterSamples-01
  /// <summary>
  /// ImageConverter�N���X�̃T���v���ł��B
  /// </summary>
  public class ImageConverterSamples01 : IExecutable
  {
    public void Execute()
    {
      //
      // Image�I�u�W�F�N�g���擾.
      //
      GDIImage image = GDIImage.FromFile("database.png");

      //
      // Image���o�C�g�z��ɕϊ�.
      //   Image����ʂ̃I�u�W�F�N�g�ɕϊ�����ꍇ��ConvertTo�𗘗p����.
      //
      ImageConverter converter = new ImageConverter();
      byte[] imageBytes = (byte[])converter.ConvertTo(image, typeof(byte[]));

      //
      // �o�C�g�z���Image�ɕϊ�.
      //   �o�C�g�z�񂩂�Image�I�u�W�F�N�g�ɕϊ�����ꍇ��ConvertFrom�𗘗p����.
      //
      GDIImage image2 = (GDIImage)converter.ConvertFrom(imageBytes);

      // �m�F.
      Debug.Assert(image != null);
      Debug.Assert(imageBytes != null && imageBytes.Length > 0);
      Debug.Assert(image2 != null);

      //
      // [�⑫]
      // Image�I�u�W�F�N�g���t�@�C���Ƃ��ĕۑ�����ꍇ�͈ȉ��̂悤�ɂ���.
      //
      //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      //string fileName    = @"Sample.png";
      //string filePath    = Path.Combine(desktopPath, fileName);
      //
      //using (Stream stream = File.Create(filePath))
      //{
      //  image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
      //}
    }
  }
  #endregion
}
