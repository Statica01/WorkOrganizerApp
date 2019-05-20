using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkOrganizerApp.Models;

namespace WorkOrganizerApp.Services
{
    internal class ProjectApiService
    {

        public async Task<List<Project>> GetProjectsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/projects");

            var projects = JsonConvert.DeserializeObject<List<Project>>(json);

            return projects;
        }

        public async Task PostProjectAsync(Project project, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(project);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BaseApiAddress + "api/Projects", content);
        }

        public async Task EditProjectAsync(Project project, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(project);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(
                Constants.BaseApiAddress + "api/Ideas/" + project.Id, content);
        }

        public async Task DeleteProjectAsync(int projectId, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync(
                Constants.BaseApiAddress + "api/projects/" + projectId);
        }

        public async Task<List<Project>> SearchProjectsAsync(string keyword, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(
                Constants.BaseApiAddress + "api/projects/Search/" + keyword);

            var projects = JsonConvert.DeserializeObject<List<Project>>(json);

            return projects;
        }
    }
}
