
function PostFormWithSwal(title, text, icon, dangerMode, url, success)
{
  swal({
    title: title,
    text: text,
    icon: icon,
    buttons: true,
    dangerMode: dangerMode
  }).then((confirmed) =>
  {
    if (confirmed)
    {
      $.ajax({
        type: "POST",
        url: url,
        beforeSend: function ()
        {
          //$("#loaderDiv").show()
          //window.setTimeout($("#loaderDiv").show(), 5000);
        },
        error: function (xhr, ajaxOptions, thrownError)
        {
          swal({ title: 'Failed', text: "Something went wrong, try again!", icon: 'error' });
        },
        success: function (data)
        {
          //$("#loaderDiv").hide();
          swal({ title: 'Complete', text: success, icon: 'success' });
        }
      });
    }
  });
}


function SweetConfirmCancel(id, command, action)
{
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: command + ' Bid'
    }).then((result) =>
        {
            if (result.isConfirmed)
            {
                window.location.href = "/Dashboard/"+action+"/"+id;
            }
    })
}

function SweetConfirmAuction(command, message,controller,action, id) 
{
    Swal.fire({
        title: 'Are you sure?',
        text: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: command
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = "/" + controller +"/" + action + "/" + id;
        }
    })
}

function SweetDone() 
{
    Swal.fire({
        title: 'Good',
        text: "Perfect",
        icon: 'success'
    })
}

function CheckPassword(Password)
{
    let strongPassword = new RegExp('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})');
    if(strongPassword.test(Password)) 
    {
        return true;
    }
    return false;
}

function ValidatePersonalInfoApply()
{
    var idNum =  $("#idNum").val();
    var bEmail = $("#bEmail").val();
    var cell = $("#cell").val();

    var idRegex = /^(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))/;
    var emailRegex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var cellRegex = /^0(1|6|7|8){1}[0-9]{1}[0-9]{7}$/;

    var allValid = true;
    if(idRegex.test(idNum) === false)
    {
        $("#idNumValid").text("Please supply a valid ID number");
        allValid = false;
    }
    else
    {
        $("#idNumValid").text("");
    }
    if(!bEmail.match(emailRegex))
    {
        $("#emailValid").text("Please enter a valid email");
        allValid = false;
    }
    else
    {
        $("#emailValid").text("");
    }
    if (cellRegex.test(cell) === false)
    {
        $("#cellValid").text("Please enter a valid email")
        allValid  = false;
    }
    else
    {
        $("#cellValid").text("");
    }
    return allValid;
}

function ValidateBusinessInfoApply()
{
    var bName = $("#bName").val();
    var regNum = $("#regNum").val();
    var web = $("#web").val();
    var address = $("#address").val();

    var allValid = true;

    if(bName == "")
    {
        $("#bNameValid").text("Please enter Business Name");
        allValid  = false;
    }
    else
    {
         $("#bNameValid").text("");
    }
    if(regNum == "")
    {
        $("#regNumValid").text("Please enter Registration Number");
        allValid  = false;
    }
    else
    {
        $("#regNumValid").text("");
    }
    if(address == "")
    {
        $("#addressValid").text("Please enter Registration Number");
        allValid  = false;
    }
    else
    {
        $("#addressValid").text("");
    }
    return allValid;
}

function ValidatePurchaseOrderInfoApply()
{
    var poDesc = $("#poDesc").val();
    var contactPerson = $("#contactPerson").val();
    var poIssueDate = $("#poIssueDate").val();
    var poDueDate = $("#poDueDate").val();
    var poAmt = $("#poAmt").val();
    var invAmt = $("#invAmt").val();
    var poOrdNum = $("#poOrdNum").val();
    var goodsSupplier = $("#goodsSupplier").val();

    var allValid = true;
    var today = new Date();

    if(poDesc == "")
    {
        $("#poDescValid").text("Please enter Purcahse Order Description");
        allValid  = false;
    }
    else
    {
         $("#poDescValid").text("");
    }
    if(contactPerson == "")
    {
        $("#contactPersonValid").text("Please enter contact person Phone number");
        allValid  = false;
    }
    else
    {
        $("#contactPersonValid").text("");
    }
    if(poIssueDate > today || poIssueDate > poDueDate)
    {
        if(poIssueDate > today) $("#poIssueDateValid").text("Issue date cannot be on a later date than today's date");
        if(poIssueDate > poDueDate) $("#poIssueDateValid").text("Issue date cannot be on a later date than due date");
        allValid  = false;
    }
    else
    {
        $("#poIssueDateValid").text("");
    }
    if(poDueDate < today || poDueDate < poIssueDate)
    {
        if(poDueDate < today) $("#poDueDateValid").text("Due date cannot be on a earlier date than today's date");
        if(poDueDate < poIssueDate) $("#poDueDateValid").text("Due date cannot be on a earlier date than Issue date");
        allValid  = false;
    }
    else
    {
        $("#poDueDateValid").text("");
    }
     if(poAmt == "")
    {
        $("#poAmtValid").text("Please enter Purchase Order Amount");
        allValid  = false;
    }
    else
    {
         $("#poAmtValid").text("");
    }
    if(invAmt == "")
    {
        $("#invAmtValid").text("Please enter Invoice Amount");
        allValid  = false;
    }
    else
    {
        $("#invAmtValid").text("");
    }
     if(poOrdNum == "")
    {
        $("#poNumValid").text("Please enter Purcahse Order Number");
        allValid  = false;
    }
    else
    {
         $("#poNumValid").text("");
    }
    if(goodsSupplier == "")
    {
        $("#goodsSupplierValid").text("Please enter goods supplier");
        allValid  = false;
    }
    else
    {
        $("#goodsSupplierValid").text("");
    }
    return allValid;
}

function ValidateDocumentsApply()
{
    var bizReg = $("#businessRegistrationDoc");
    var dirId = $("#directorIdDoc");
    var poDoc = $("#PurchaseOrderDoc");
    var quoDoc = $("#QuoationDoc");

    var allValid  = true;

    if(bizReg.get(0).files.length === 0)
    {
        $("#businessRegistrationDocValid").text("Please attach Business Registration Document");
        allValid  = false;
    }
    else
    {
        $("#businessRegistrationDocValid").text("");
    }
    if(dirId.get(0).files.length === 0)
    {
        $("#directorIdDocValid").text("Please attach Director's ID Document");
        allValid  = false;
    }
    else
    {
        $("#directorIdDocValid").text("");
    }
    if(poDoc.get(0).files.length === 0)
    {
        $("#PurchaseOrderDocValid").text("Please attach Purchase Order Document");
        allValid  = false;
    }
    else
    {
        $("#PurchaseOrderDocValid").text("");
    }
    if(quoDoc.get(0).files.length === 0)
    {
        $("#QuoationDocValid").text("Please attach Order Quotation");
        allValid  = false;
    }
    else
    {
        $("#QuoationDocValid").text("");
    }
    return allValid;
}
