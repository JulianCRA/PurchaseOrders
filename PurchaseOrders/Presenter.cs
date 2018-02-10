using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders
{
    public class Presenter : IPresenter
    {
        protected IView _form;
        protected IGateway _list;

        public Presenter(IView form, IGateway list)
        {
            _form = form;
            _list = list;

            _form.userInteracted += this.Form_OnUserInteracted;
        }

        public void Form_OnUserInteracted(object sender, UserInteractedEventArgs e)
        {
            switch (e.action)
            {
                case "del":
                    Delete();
                    break;
                case "sel":
                    GetByID();
                    break;
                case "syn":
                    SynchronizeView();
                    break;
                case "add":
                    Insert();
                    break;
                case "edt":
                    Update();
                    break;
                case "clr":
                    SynchronizeView();
                    break;
            }
        }

        public void Insert()
        {
            switch (_list.Insert(_form.GetFormInfo()))
            {
                case DatabaseConnection.QueryStatus.Success:
                    SynchronizeView();
                    _form.DisplayMsg(1, "Submission successful");
                    break;
                case DatabaseConnection.QueryStatus.Fail:
                    _form.DisplayMsg(0, "The ID is already assigned, please select a different ID or let the application do it automatically");
                    break;
                case DatabaseConnection.QueryStatus.DataError:
                    //invalid data
                    break;
            }
        }

        public void Update()
        {
            switch (_list.Update(_form.GetFormInfo()))
            {
                case DatabaseConnection.QueryStatus.Fail:
                    _form.DisplayMsg(0, "Transaction rejected. Please contact your local network admin"); //Likely a connection issue
                    break;
                case DatabaseConnection.QueryStatus.Success:
                    SynchronizeView();
                    _form.DisplayMsg(1, "Changes saved successfully");
                    break;
                case DatabaseConnection.QueryStatus.DataError:
                    _form.DisplayMsg(0, "Data format invalid");
                    break;
            }
        }

        public void Delete()
        {
            _list.Delete(_form.SelectedIndex);
            SynchronizeView();
        }

        public virtual void SynchronizeView()
        {
            return;
        }

        public void GetByID()
        {
            if (_list.Find(_form.SelectedIndex) != null)
                _form.EnterEditionMode(_list.Find(_form.SelectedIndex));
        }
    }
}
