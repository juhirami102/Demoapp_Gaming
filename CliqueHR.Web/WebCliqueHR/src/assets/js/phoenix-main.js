$(document).ready(function () {
    buttonRipple();
    $('.carousel').carousel('pause');
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-tooltip="tooltip"]').tooltip();

    $(".image-list > .image-item").click(function(){
        $(this).parent().find(".selected-image").removeClass("selected-image");
        $(this).addClass("selected-image");
        var selectedImgUrl = $(".selected-image > img").attr('src');
        $(".body").css("background-image", "url(" + selectedImgUrl + ")");
    });

    $(".admin-image-list > .admin-image-item").click(function(){
        $(this).toggleClass("selected-image");
    });

    $('.theme-mode input[type=radio]').change(function() {
        // jQuery("body").prepend('<div class="custom-preloader">\
        //     <img src="images/logo.png" />\
        // </div>');
        if (this.value == 'light') {
            $(".body").removeClass("dark-theme");
        }
        else if (this.value == 'dark') {
            $(".body").addClass("dark-theme");
        }
    });

    $('.rounded-mode input[type=radio]').change(function() {
        if (this.value == "rounded") {
            $(".body").addClass("border-rounded");
        }
        else if(this.value == "flat"){
            $(".body").removeClass("border-rounded");
        }
    });

    /* For File Inut value print */
    $("input.custom-file-input").on("change",function(){
        //get the file name
        var fileName = $(this).val();
        str = fileName.replace(/C:\\fakepath\\/i,'');
        //replace the "Choose a file" label
        $(this).parent().parent().parent().find('.file-name').html(str);
    });

    // $('link[rel=stylesheet][href="css/phoenix-theme.css"]').remove();
    // $('head').append('<link rel="stylesheet" href="css/phoenix-dark-theme.css" type="text/css" />');

    /* menu open close wrapper screen click close menu */
    $('.menu-btn').on('click', function (e) {
        e.stopPropagation();
        if ($('body').hasClass('sidemenu-open') == true) {
            $('body').removeClass('sidemenu-open');
            setTimeout(function () {
                $('body').removeClass('menuactive');
            }, 500);
        } else {
            $('body').addClass('sidemenu-open menuactive');
        }
    });
    $('.outer-wrapper').on('click', function () {
        if ($('body').hasClass('sidemenu-open') == true) {
            $('body').removeClass('sidemenu-open');
            setTimeout(function () {
                $('body').removeClass('menuactive');
            }, 500);
        }
    });

    $(".setting-btn").click(function(){
        $(".setting-box").css("display","block");
        $(".main-menu").css("display","none");
    });
    $(".back-btn").click(function(){
        $(".setting-box").css("display","none");
        $(".main-menu").css("display","block");
    });
    
    /* Float label checking input is not empty */
    $('.float-label .form-control').on('blur', function () {
        if ($(this).val() || $(this).val().length != 0) {
            $(this).closest('.float-label').addClass('active');
        } else {
            $(this).closest('.float-label').removeClass('active');
        }
    })

    /* Full Menu */                
    $("#footer-menu .btn-bounce").on("click",function(){
        $(this).parents('.footer-menu').toggleClass("footer-expanded");
    });    

    /* Footer Search*/
    $(".footer-search").click(function(){
        $(".footer-search-open").css("display","block");
    });
    $(".footer-search-open .input-group-text").click(function(){
        $(this).parents().find(".footer-search-open").css("display","none");
    });
    /* End */

    /* always keep at least 1 open by preventing the current to close itself */
    $('[data-toggle="collapse"].slider-item-custom').on('click',function(e){
        if ( $(this).parents('.wrapper').find('.collapse.show') ){
            var idx = $(this).index('[data-toggle="collapse"].slider-item-custom');
            if (idx == $('.collapse.show').index('.collapse')) {
                // prevent collapse
                e.stopPropagation();
            }
        }
    });
    
});

/* Button Animation Effect Start */
function buttonRipple(e){
    $(".btn").click(function (e) {
        // Remove any old one
        $(".ripple").remove();
    
        // Setup
        var posX = $(this).offset().left,
            posY = $(this).offset().top,
            buttonWidth = $(this).width(),
            buttonHeight =  $(this).height();
        
        // Add the element
        $(this).prepend("<span class='ripple'></span>");
    
        
        // Make it round!
        if(buttonWidth >= buttonHeight) {
            buttonHeight = buttonWidth;
        } else {
            buttonWidth = buttonHeight; 
        }
        
        // Get the center of the element
        var x = e.pageX - posX - buttonWidth / 2;
        var y = e.pageY - posY - buttonHeight / 2;
        
        
        // Add the ripples CSS and start the animation
        $(".ripple").css({
            width: buttonWidth,
            height: buttonHeight,
            top: y + 'px',
            left: x + 'px'
        }).addClass("rippleEffect");
    });
}
/* Button Animation Effect End */

function matchStart(params, data) {
    // If there are no search terms, return all of the data
    if ($.trim(params.term) === '') {
        return data;
    }

    // Skip if there is no 'children' property
    if (typeof data.children === 'undefined') {
        return null;
    }

    // `data.children` contains the actual options that we are matching against
    var filteredChildren = [];
    $.each(data.children, function (idx, child) {
        if (child.text.toUpperCase().indexOf(params.term.toUpperCase()) == 0) {
        filteredChildren.push(child);
        }
    });

    // If we matched any of the timezone group's children, then set the matched children on the group
    // and return the group object
    if (filteredChildren.length) {
        var modifiedData = $.extend({}, data, true);
        modifiedData.children = filteredChildren;

        // You can return modified objects from here
        // This includes matching the `children` how you want in nested data sets
        return modifiedData;
    }

    // Return `null` if the term should not be displayed
    return null;
}
