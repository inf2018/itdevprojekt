$('#searchInput').bind("change keyup input click", function () {
    token('searchInput', 'tokenList');
    if (this.value.length >= 2) {
        var value = $("#tokenList").val();
        //$.ajax({
        //    type: 'POST',
        //    url: '/Search/SearchResult',
        //    data: {
        //        token: $("#tokenList").val(),
        //    },
        //    response: 'text',
        //    success: function (data) {
        //        //$(".search-items").show();
        //     console.log(data);
        //    //    //$(".search-items").html(data).show();
        //    //    data.forEach(InsertData);
        //    //    maxLength();
        //    //    check();
        //    }
        //});
    }
});


//function maxLength() {
//    var item_text = document.querySelectorAll('.item-text');
//    item_text.forEach(function (item) {
//        let str = item.innerText;
//        if (str.length > 100) {
//            var new_str = str.substr(0, 75) + '...';
//            item.innerHTML = new_str;
//        }
//    })
//}

//function check() {
//    var search_items = document.querySelectorAll('.search-item');
//    //if (search_items.length == 0) {
//    //    $('.search-items').css('display', 'none');
//    //}
//}