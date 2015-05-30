﻿// <autogenerated>
//   This file was generated by T4 code generator Dto.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Mes.Demo.Contracts;
using Mes.Demo.Dtos.Test;
using Mes.Demo.Models.Test;
using Mes.Utility;
using Mes.Utility.Data;
using Mes.Web.Mvc.Binders;
using Mes.Web.Mvc.Security;
using Mes.Web.UI;


namespace Mes.Demo.Web.Areas.Admin.Controllers
{
    public class LineController : AdminBaseController
    {
        public ITestContract TestContract { get; set; }



        [AjaxOnly]
        public ActionResult GridData(int? id)
        {
            int total;
            GridRequest request = new GridRequest(Request);
            var datas = GetQueryData<Line, int>(TestContract.Lines, out total, request).Select(m => new
            {
                m.Name,
                m.Remark,
                m.IsAdmin,
                m.IsLocked,
                m.Id,
                m.IsDeleted,
                m.CreatedTime,
        
            });
            return Json(new GridData<object>(datas, total), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Add([ModelBinder(typeof(JsonBinder<LineDto>))] ICollection<LineDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = TestContract.AddLines(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Edit([ModelBinder(typeof(JsonBinder<LineDto>))] ICollection<LineDto> dtos)
        {
            dtos.CheckNotNull("dtos");
            OperationResult result = TestContract.EditLines(dtos.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Delete([ModelBinder(typeof(JsonBinder<int>))] ICollection<int> ids)
        {
            ids.CheckNotNull("ids");
            OperationResult result = TestContract.DeleteLines(ids.ToArray());
            return Json(result.ToAjaxResult(), JsonRequestBehavior.AllowGet);
        }
       
	}
}