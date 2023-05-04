
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
