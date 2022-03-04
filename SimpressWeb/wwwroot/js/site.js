$(".edit-btn").click(function () {
    $.get({
        url: "Product/Edit/" + $(this).val(),
        data: $(this).val()
    }).done(function (data) {
        //console.log(data);
        $("#ProductId").val(data.id);
        $("#Name").val(data.name);
        $("#Description").val(data.description);
        //$("#ProductCategory").val(JSON.stringify(data.productCategory));
        $("#ProductCategoryId").val(data.productCategoryId);
        $("#Perishable").attr(data.perishable ? "checked" : "");
    });
});

$(".delete-btn").click(function () {
    $.post({
        url: "Product/Delete/" + $(this).val(),
        data: $(this).val()
    }).done(function () {
        location.reload();
    });
});