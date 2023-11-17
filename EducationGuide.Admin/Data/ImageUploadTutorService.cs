﻿using Core.Models.Domain;
using Microsoft.AspNetCore.Components.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EducationGuide.Admin.Data
{
    public class ImageUploadTutorService
    {
        public ImageUploadTutorService(IConfiguration config)
        {
            this.config = config;
        }
        private long maxFileSize = 1024 * 1024 * 20;
        private int maxAllowedFiles = 1;
        private List<string> errors = new();
        private readonly IConfiguration config;

        public async Task<string> CaptureFileImg(IBrowserFile? file, Tutors tutors, string fileStore)
        {
            if(file == null)
            {
                return tutors.ImgUrl;
            }

            try
            {
                string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
                string directoryPath = Path.Combine(config.GetValue<string>("FileStorage")!, fileStore);
                Directory.CreateDirectory(directoryPath);
                string path = Path.Combine(directoryPath, newFileName);
                string relativePath = Path.Combine(fileStore, newFileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream(maxFileSize).CopyToAsync(fs);
                return relativePath;
            }
            catch (Exception ex)
            {
                errors.Add($"File: {file.Name} Error: {ex.Message}");
                throw;
            }
        }         
        
        public async Task<string> CaptureFileCreateImg(IBrowserFile? file, string fileStore)
        {
            

            try
            {
                string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
                string directoryPath = Path.Combine(config.GetValue<string>("FileStorage")!, fileStore);
                Directory.CreateDirectory(directoryPath);
                string path = Path.Combine(directoryPath, newFileName);
                string relativePath = Path.Combine(fileStore, newFileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream(maxFileSize).CopyToAsync(fs);
                return relativePath;
            }
            catch (Exception ex)
            {
                errors.Add($"File: {file.Name} Error: {ex.Message}");
                throw;
            }
        }        
        

    }
    }

