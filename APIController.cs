using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using Microsoft.Extensions.Options;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OprecKPL
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        string fileName = @"daftarMahasiswa.json";
        // GET: api/<APIController>
        [HttpGet]
        public Mahasiswa[] Get()
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
            return JsonSerializer.Deserialize<Mahasiswa[]>(fileName, options);
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public Mahasiswa Get(int id)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
            return JsonSerializer.Deserialize<Mahasiswa[]>(fileName, options)[id];
        }

        // POST api/<APIController>
        [HttpPost]
        public void Post(Mahasiswa mahasiswa)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            Mahasiswa[] daftarMahasiswa = JsonSerializer.Deserialize<Mahasiswa[]>(fileName, options);
            daftarMahasiswa.Append(mahasiswa);
            string jsonString = JsonSerializer.Serialize(daftarMahasiswa, options);
            System.IO.File.WriteAllText(fileName, jsonString);
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Mahasiswa mahasiswa)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            Mahasiswa[] daftarMahasiswa = JsonSerializer.Deserialize<Mahasiswa[]>(fileName, options);
            daftarMahasiswa.SetValue(mahasiswa, id);
            string jsonString = JsonSerializer.Serialize(daftarMahasiswa, options);
            System.IO.File.WriteAllText(fileName, jsonString);
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            Mahasiswa[] daftarMahasiswa = JsonSerializer.Deserialize<Mahasiswa[]>(fileName, options);

            for (int i = id + 1; i < daftarMahasiswa.Length; i++)
            {
                daftarMahasiswa[i - 1] = daftarMahasiswa[i];
            }
            // set the last element to zero
            daftarMahasiswa[daftarMahasiswa.Length - 1] = null;
            string jsonString = JsonSerializer.Serialize(daftarMahasiswa, options);
            System.IO.File.WriteAllText(fileName, jsonString);
        }
    }
}
