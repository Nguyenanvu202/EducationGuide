/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using EducationGuide.Admin;
using EducationGuide.Admin.Shared;
using Radzen;
using Radzen.Blazor;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Core.Models.Domain;

namespace EducationGuide.Admin.Pages
{
    public partial class ImageUpload
    {
        private long maxFileSize = 1024 * 1024 * 20;
        private int maxAllowedFiles = 1;
        private List<string> errors = new();
        private IBrowserFile? file;
        private Section newSectionImage = new Section();


        private void LoadFile(InputFileChangeEventArgs e)
        {
            file = e.File;
        }

        private async Task<string> CaptureFile()
        {
            if (file is null)
            {
                return "";
            }

            errors.Clear();
            try
            {
                string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
                string path = Path.Combine(config.GetValue<string>("FileStorage")!, "Home", newFileName);
                Directory.CreateDirectory(Path.Combine(config.GetValue<string>("FileStorage")!, "Image"));
                string relativePath = Path.Combine("Home", newFileName);
                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream().CopyToAsync(fs);
                return relativePath;
            }
            catch (Exception ex)
            {
                errors.Add($"File: {file.Name} Error: {ex.Message}");
                throw;
            }
        }
    }
}*/