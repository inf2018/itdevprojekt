$(document).ready(function() {
	show();
    document.getElementById('textTo').value = "";
    document.getElementById('textFrom').value = "";
    $('.textarea').keyup(function() {
    	translate();
    });
    $('.select').change(function() {
    	translate();
    });
});

function show() {
	$('.tlum-page').fadeIn("slow");
	$('.list-page').fadeIn("slow");
	setTimeout(function(){
          $('.block-tlum').toggleClass("active");
          $('.logo-main').fadeIn("slow");
          $('.logo-main').css("display", "flex");
    }, 500);
    setTimeout(function(){
          $('.block-lista').toggleClass("active");
    }, 1500);
    $('.searchBox').val("");
    setTimeout(function(){
    	$('.searchBox').toggleClass('inclicked');
    }, 100);
    setTimeout(function(){
    	$('.searchBtn').css("opacity", 1);
    }, 1000);	
};

function token(textarea_id, token_id) {
	let text = document.getElementById(textarea_id).value;
	let text_row = '', text_start, text_end, text_middle;
	text_start = Math.round((text.length * 20) / 100);
	text_middle = Math.round((text.length * 50) / 100);
	text_end = text.length;
	text = text.trim().toLowerCase();
	text = text.split(' ').join('');
	if(text.length > 200) {
		text_row = text.substr(0, 50);
		text_row += text.substr(text_middle - 25, text_middle + 25);
		text_row += text.substr(text_end - 50, text_end);
	}
	else
		text_row = text;
	document.getElementById(token_id).value = text_row;
}

function Insert(){
    translate();
    token('textFrom', 'token');
      $.ajax({
          type: 'POST',
          url: '/Translate/Create',
          data: {
              LangSource: $("#fromS").val(),
              LangTranslate: $("#toS").val(),
              TextBefore: $("#textFrom").val(),
              TextAfter: $("#textTo").val(),
              TextToken: $("#token").val(),
          },
          success: function (response) {
              console.log(response);
              alert("data inserted");
        }
      });
      return false;
};

function translate(){
	if(document.getElementById('textFrom').value != ''){
	var from = document.getElementById('textFrom').value;
	var langFrom = document.getElementById('fromS').value;
	var langTo = document.getElementById('toS').value;
	document.getElementById("translate-btn").disabled = true;
	var key = 'trnsl.1.1.20190322T104153Z.c9f9fed68a5e645b.aea75e23f6083c1a22a773d70c8bf83fb0f782c6',
	api = 'https://translate.yandex.net/api/v1.5/tr.json/translate';
	var url = api+'?';
	url += 'key='+key;	
	url += '&text='+from;	
	url += '&lang='+langFrom + '-' + langTo;
	var ajax = new XMLHttpRequest();	
	ajax.open('GET', url, true);
	ajax.onreadystatechange = function() {
		if(ajax.readyState == 4) {
			if(ajax.status == 200) {
				from = ajax.responseText;
				from = JSON.parse(from);
				from = from.text;
				document.getElementById("translate-btn").disabled = false;
				var textTo = from;
				document.getElementById('textTo').value = textTo;
			}
		}
	};
	ajax.send(null); 
	}
	else {
		document.getElementById('textTo').value = "";
	}
return textTo.value;
};