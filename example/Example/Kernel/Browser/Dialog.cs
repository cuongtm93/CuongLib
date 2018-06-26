using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Kernel.Attributes;
namespace Kernel.Browser
{

    /// <summary>
    ///  Dialog có thể sử dụng data
    /// </summary>
    public class Dialog : Data
    {
        /// <summary>
        /// DialogId trên trình duyệt
        /// </summary>
        public string dialogId;

        /// <summary>
        ///  Tiêu đề của dialog
        /// </summary>
        public string Title;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dialogId">Cho phép hiển thị dialog khi khi _dialogId khác rỗng</param>
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
        public virtual void CreateModalDialog(string CreateddialogId = "")
        {
            if (!string.IsNullOrWhiteSpace(CreateddialogId))
            {
                // Showdialog đã khởi tạo xong
                query(CreateddialogId.Id()).modal("show");
            }
            else
            {
                // Show dialog đang khởi tạo (bằng từ khóa new)
                FillDialogData();
                query(this.dialogId.Id()).modal("show");
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
                query(this.dialogId.Id()).modal("hide");
            }
            else
            {
                query(dialogId.Id()).modal("hide");
            }
        }


        /// <summary>
        ///  Điền giá trị cho các field trong dialog
        /// </summary>
        public virtual void FillDialogData()
        {
            // Với từng dialog cụ thể thì hàm này sẽ được định nghĩa lại
        }
                       

        public virtual void SetTitle(string Title)
        {
            dom.document.getElementById("dialogtitle").innerHTML = Title;
        }

    }
}
