using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CoreShop_V2.Areas.Admin.ViewModel;
using FinalProjectASPDotnet.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreShop_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MgnBillController : Controller
    {
        private readonly MyDbContext _dbContext;
        public readonly IMapper _mapper;

        public MgnBillController(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [Route("BillMgn")]
        public IActionResult BillManagement()
        {
            //BillManagementViewModel bill = new BillManagementViewModel();
            //var allBill = await _dbContext.Bill.ToListAsync();
            //bill.Bill = _mapper.Map<List<BillMgnViewModel>>(allBill);
            return View();
        }

        [HttpPost]
        [Route("LoadBillData")]
        public async Task<IActionResult> LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all data
                BillManagementViewModel bill = new BillManagementViewModel();
                var allBill = await _dbContext.Bill.ToListAsync();
                bill.Bill = _mapper.Map<List<BillMgnViewModel>>(allBill);           

                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    if(sortColumnDirection == "desc")
                    {
                        bill.Bill = bill.Bill.OrderByDescending(x => x.CreateDate).ToList();
                    }
                    else
                    {
                        bill.Bill = bill.Bill.OrderBy(x => x.CreateDate).ToList();
                    }                    
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    var billSearch = bill.Bill.Where(m => m.CreateDate.ToString().Contains(searchValue)).ToList();
                    var leftOver = bill.Bill.Except(billSearch).ToList();

                    billSearch.AddRange(leftOver.Where(m => m.CustomerEmail.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(billSearch).ToList();

                    billSearch.AddRange(leftOver.Where(m => m.CustomerAddress.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(billSearch).ToList();

                    billSearch.AddRange(leftOver.Where(m => m.CustomerPhone.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(billSearch).ToList();

                    billSearch.AddRange(leftOver.Where(m => m.CreateDate.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(billSearch).ToList();

                    billSearch.AddRange(leftOver.Where(m => m.Status.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(billSearch).ToList();

                    billSearch.AddRange(leftOver.Where(m => m.AccountId.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(billSearch).ToList();

                    billSearch.AddRange(leftOver.Where(m => m.CustomerName.ToString().Contains(searchValue)).ToList());
                    leftOver = leftOver.Except(billSearch).ToList();

                    bill.Bill = billSearch;
                }
                
                //total number of rows count   
                recordsTotal = bill.Bill.Count();
                //Paging   
                var data = bill.Bill.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data   
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetBillDetail/{billId}")]
        public async Task<IActionResult> GetBillDetail(string billId)
        {
            var thisbill = await _dbContext.Bill.Include(x=>x.BillDetails).FirstOrDefaultAsync(x => x.BillId == billId);
            var billdetail = _mapper.Map<BillMgnViewModel>(thisbill);
            return PartialView(billdetail);
        }
    }
}