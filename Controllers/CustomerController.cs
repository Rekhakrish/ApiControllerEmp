using Microsoft.AspNetCore.Mvc;
using CoreWebApiExample.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebApiExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CoreApiEx> Get()
        {
            using (var context=new SingleTableContext())
            {
                return context.CoreApiExes.ToList();
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CoreApiEx Get(int id)
        {
            using (var context = new SingleTableContext())
            {
                return context.CoreApiExes.FirstOrDefault(item => item.ExampleId == id);
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<CoreApiEx> Post([FromBody] CoreApiEx value)
        {
            using (var context = new SingleTableContext())
            {
                context.CoreApiExes.Add(value);
                context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = value.ExampleId }, value);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CoreApiEx value)
        {
            using (var context = new SingleTableContext())
            {
                var item=context.CoreApiExes.FirstOrDefault(item =>item.ExampleId == id);
                if (item != null)
                {
                    item.ProjectName = value.ProjectName;
                    item.CreatedBy = value.CreatedBy;
                    item.CreatedDate = value.CreatedDate;
                    context.SaveChanges();
                }
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new SingleTableContext())
            {
                var item = context.CoreApiExes.FirstOrDefault(item => item.ExampleId == id);
                if (item != null)
                {
                    context.CoreApiExes.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
