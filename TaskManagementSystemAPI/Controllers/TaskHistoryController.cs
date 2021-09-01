using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/task-history")]
    public class TaskHistoryController : ControllerBase
    {
        private readonly ITaskHistoryService _taskHistoryService;

        public TaskHistoryController(ITaskHistoryService taskHistoryService)
        {
            _taskHistoryService = taskHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _taskHistoryService.GetTaskHistory();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskHistoryRequestModel taskHistoryUpdateRequestModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);
                var res = await _taskHistoryService.AddTaskHistory(taskHistoryUpdateRequestModel);
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskHistoryUpdateRequestModel taskHistoryUpdateRequestModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values);

                var res = await _taskHistoryService.UpdateTaskHistory(taskHistoryUpdateRequestModel);
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            try
            {
                var task = await _taskHistoryService.GetTaskHistoryById(id);
                return task == null ? NotFound() : Ok(task);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await _taskHistoryService.DeleteTaskHistory(id);
                return task ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
