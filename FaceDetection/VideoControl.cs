using System;
using System.IO;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace FaceDetection
{
    public class VideoControl
    {
        public void ExtractImagesFromVideo(string videoPath, string outputFolder)
        {
            using var engine = new Engine();
            var mp4 = new MediaFile {Filename = videoPath};

            engine.GetMetadata(mp4);

            var i = 0;
            while (i < mp4.Metadata.Duration.Seconds)
            {
                var options = new ConversionOptions {Seek = TimeSpan.FromSeconds(i)};
                var outputFile = new MediaFile {Filename = Path.Combine(outputFolder,$"image-{i}.jpeg")};
                engine.GetThumbnail(mp4, outputFile, options);
                i++;
            }
        }

        public void ExtractImagesFromVideoFolder(string videosPath, string outputFolder)
        {
            var files = Directory.GetFiles(videosPath);

            using var engine = new Engine();
            
            for (var i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"Processing frames from video {i}/{files.Length}");
                var videoFolder = Path.Combine(outputFolder, Path.GetFileName(files[i]).Replace(".mp4",""));
                Directory.CreateDirectory(videoFolder);
                var mp4 = new MediaFile {Filename = files[i]};
                engine.GetMetadata(mp4);

                var x = 0;
                while (x < mp4?.Metadata?.Duration.Seconds)
                {
                    var options = new ConversionOptions {Seek = TimeSpan.FromSeconds(x)};
                    var outputFile = new MediaFile {Filename = Path.Combine(videoFolder,$"image-{x}.jpeg")};
                    engine.GetThumbnail(mp4, outputFile, options);
                    x++;
                }
            }
        }
    }
}