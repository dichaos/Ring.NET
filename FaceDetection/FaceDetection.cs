using System;
using System.IO;
using System.Linq;
using FaceRecognitionDotNet;

namespace FaceDetection
{
    public class FaceDetection
    {
        public void ExtractFaceImages(string imagesFolder, string outputDirectory)
        {
            var directories = Directory.GetDirectories(imagesFolder);

            using var f = FaceRecognition.Create(Directory.GetCurrentDirectory());
            
            for(int i = 0; i < directories.Length; i++)
            {
                Console.WriteLine($"Processing {i}/{directories.Length}");
                var folderName = Path.GetFileName(directories[i]);
                ExtractFromDirectory(directories[i], Path.Combine(outputDirectory, folderName), f);
            }
        }

        private void ExtractFromDirectory(string imagesFolder, string outputDirectory, FaceRecognition f)
        {
            var imagePaths = Directory.GetFiles(imagesFolder);

            for(var i = 0 ; i < imagePaths.Length; i++)
            {
                using var image = FaceRecognition.LoadImageFile(imagePaths[i]);
                
                var locations = f.FaceLocations(image).ToList();
                
                if (locations.Count > 0)
                {
                    var faceImages = FaceRecognition.CropFaces(image, locations).ToList();
                    
                    if(!Directory.Exists(outputDirectory))
                        Directory.CreateDirectory(outputDirectory);

                    var name = Path.GetFileName(imagePaths[i].Split(".")[0]);
                    
                    image.Save(Path.Combine(outputDirectory, $"{name}-{i}.jpeg"), ImageFormat.Jpeg);
                    
                    for (var x = 0; x < faceImages.Count; x++)
                    {
                        faceImages[x].Save(Path.Combine(outputDirectory, $"{name}-face-{i}-{x}.jpeg"), ImageFormat.Jpeg);
                    }
                    
                    faceImages?.ForEach(x => x?.Dispose());
                }
            }
        }
    }
}