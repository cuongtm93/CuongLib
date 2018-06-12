using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Library.Attributes;

namespace Library.Browser
{

    /// <summary>
    ///  Dialog có thể sử dụng data
    /// </summary>
    public class Dialog : Data
    {
        public string dialogId;

        public string Title = "";

        /// <summary>
        /// Cho phép hiển thị dialog khi khởi tạo class này
        /// </summary>
        /// <param name="_dialogId"></param>
        /// 
        [Tested]
        public Dialog(string _dialogId = "")
        {
            if (!string.IsNullOrWhiteSpace(_dialogId))
            {
                this.dialogId = _dialogId;
                CreateModalDialog(_dialogId);
            }
        }

        /// <summary>
        ///  Hiển thị dialog
        /// </summary>
        /// <param name="CreateddialogId"></param>
        [Tested]
        public virtual void CreateModalDialog(string CreateddialogId="")
        {
            if (!string.IsNullOrWhiteSpace(CreateddialogId))
            {
                // Showdialog đã khởi tạo xong
                select(CreateddialogId.Id()).modal("show");
            }
            else
            {
                // Show dialog đang khởi tạo (bằng từ khóa new)
                FillDialogData();
                select(this.dialogId.Id()).modal("show");
            }
        }

        /// <summary>
        ///  Ẩn dialog
        /// </summary>
        /// <param name="dialogId"></param>
        [Tested]
        public virtual void HideModalDialog(string dialogId = "")
        {
            if (string.IsNullOrWhiteSpace(dialogId))
            {
                select(this.dialogId.Id()).modal("hide");
            }
            else
            {
                select(dialogId.Id()).modal("hide");
            }
        }


        /// <summary>
        ///  Điền giá trị cho các field trong dialog
        /// </summary>
        public virtual void FillDialogData()
        {
            // Với từng dialog cụ thể thì hàm này sẽ được định nghĩa lại
        }

        public virtual string GetChildId(string Name)
        {
            return $"{this.dialogId}_{Name}";
        }
        
        /// <summary>
        ///  Trả về đối tượng $("#parent_Name");
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public virtual dynamic GetChild(string Name)
        {
            return select(GetChildId(Name).Id());
        }

        public virtual void SetTitle(string Title)
        {
            GetChild("DialogTitle").html(Title);
        }

    }
}
