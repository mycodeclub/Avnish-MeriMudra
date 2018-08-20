/*! =========================================================
 *
 * Material Bootstrap Wizard - V1.0.1
 *
 * =========================================================
 *
 * Copyright 2016 Creative Tim (http://www.creative-tim.com/product/material-bootstrap-wizard)
 *
 *
 *                       _oo0oo_
 *                      o8888888o
 *                      88" . "88
 *                      (| -_- |)
 *                      0\  =  /0
 *                    ___/`---'\___
 *                  .' \|     |// '.
 *                 / \|||  :  |||// \
 *                / _||||| -:- |||||- \
 *               |   | \\  -  /// |   |
 *               | \_|  ''\---/''  |_/ |
 *               \  .-\__  '-'  ___/-. /
 *             ___'. .'  /--.--\  `. .'___
 *          ."" '<  `.___\_<|>_/___.' >' "".
 *         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
 *         \  \ `_.   \_ __\ /__ _/   .-` /  /
 *     =====`-.____`.___ \_____/___.-`___.-'=====
 *                       `=---='
 *
 *     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 *
 *               Buddha Bless:  "No Bugs"
 *
 * ========================================================= */

// Material Bootstrap Wizard Functions

searchVisible = 0;
transparent = true;

$(document).ready(function () {

    $.material.init();

    /*  Activate the tooltips      */
    $('[rel="tooltip"]').tooltip();

    // Code for the Validator
    var $validator = $('.wizard-card form').validate({
        rules: {
            firstname: {
                required: true,
                minlength: 3
            },
            lastname: {
                required: true,
                minlength: 3
            },
            email: {
                required: true,
                minlength: 3,
            }
        },

        errorPlacement: function (error, element) {
            $(element).parent('div').addClass('has-error');
        }
    });

    // Wizard Initialization
    $('.wizard-card').bootstrapWizard({
        'tabClass': 'nav nav-pills',
        'nextSelector': '.btn-next',
        'previousSelector': '.btn-previous',

        onNext: function (tab, navigation, index) {
            var $valid = $('.wizard-card form').valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            } else {
                var userid = getCookie("user_id_Loan");
                if (userid != null) {
                    $("#Id").val(userid);
                }
                var promise = formDataToJSON($("#from_data"), 0);
                //debugger
                promise.success(function (data) {
                    return true;
                });
            }
        },

        onInit: function (tab, navigation, index) {
            //check number of tabs and fill the entire row
            var $total = navigation.find('li').length;
            $width = 100 / $total;
            var $wizard = navigation.closest('.wizard-card');

            $display_width = $(document).width();

            if ($display_width < 600 && $total > 3) {
                $width = 50;
            }

            navigation.find('li').css('width', $width + '%');
            $first_li = navigation.find('li:first-child a').html();
            $moving_div = $('<div class="moving-tab">' + $first_li + '</div>');
            $('.wizard-card .wizard-navigation').append($moving_div);
            refreshAnimation($wizard, index);
            $('.moving-tab').css('transition', 'transform 0s');
        },

        //onTabClick: function (tab, navigation, index) {
        //    var $valid = $('.wizard-card form').valid();

        //    if (!$valid) {
        //        return false;
        //    } else {
        //        return true;
        //    }
        //},
        onTabClick: function (tab, navigation, index) {
            // alert('on tab click disabled');
            return false;
        },

        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;

            var $wizard = navigation.closest('.wizard-card');

            // If it's the last tab then hide the last button and show the finish instead
            if ($current >= $total) {
                $($wizard).find('.btn-next').hide();
                $($wizard).find('.btn-finish').show();
            } else {
                $($wizard).find('.btn-next').show();
                $($wizard).find('.btn-finish').hide();
            }

            button_text = navigation.find('li:nth-child(' + $current + ') a').html();

            setTimeout(function () {
                $('.moving-tab').text(button_text);
            }, 150);

            var checkbox = $('.footer-checkbox');

            if (!index == 0) {
                $(checkbox).css({
                    'opacity': '0',
                    'visibility': 'hidden',
                    'position': 'absolute'
                });
            } else {
                $(checkbox).css({
                    'opacity': '1',
                    'visibility': 'visible'
                });
            }

            refreshAnimation($wizard, index);
        }
    });

    $('.wizard-card .btn-finish').click(function () {
        formDataToJSON($("#from_data"), 1);
        //$('#rootwizard').find("a[href*='tab1']").trigger('click');
    });

    // Prepare the preview for profile picture
    $("#wizard-picture").change(function () {
        readURL(this);
    });

    $('[data-toggle="wizard-radio"]').click(function () {
        wizard = $(this).closest('.wizard-data');
        wizard.find('[data-toggle="wizard-radio"]').removeClass('active');
        $(this).addClass('active');
        $(wizard).find('[type="radio"]').removeAttr('checked');
        $(this).find('[type="radio"]').attr('checked', 'true');
    });

    $('[data-toggle="wizard-checkbox"]').click(function () {
        var none = "";
        if ($(this).hasClass('Other')) {
            wizard = $(this).closest('.wizard-data');
            wizard.find('[data-toggle="wizard-checkbox"]').removeClass('active');
            $(wizard).find('[type="checkbox"]').removeAttr('checked');
            $(this).addClass('active');
            $(this).find('[type="checkbox"]').attr('checked', 'true');
        } else {
            $(".Other").removeClass('active');
            $("#Other").removeAttr('checked');
            if ($(this).hasClass('none')) {
                wizard = $(this).closest('.wizard-data');
                wizard.find('[data-toggle="wizard-checkbox"]').removeClass('active');
                $(wizard).find('[type="checkbox"]').removeAttr('checked');
                $(this).addClass('active');
                $(this).find('[type="checkbox"]').attr('checked', 'true');
            } else {
                $(".none").removeClass('active');
                $("#none_Card").removeAttr('checked');
                if ($(this).hasClass('active')) {
                    $(this).removeClass('active');
                    $(this).find('[type="checkbox"]').removeAttr('checked');
                } else {
                    $(this).addClass('active');
                    $(this).find('[type="checkbox"]').attr('checked', 'true');
                }
            }
        }
    });

    $('.set-full-height').css('height', 'auto');

});



//Function to show image before upload
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#wizardPicturePreview').attr('src', e.target.result).fadeIn('slow');
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$(window).resize(function () {
    $('.wizard-card').each(function () {
        $wizard = $(this);
        index = $wizard.bootstrapWizard('currentIndex');
        refreshAnimation($wizard, index);

        $('.moving-tab').css({
            'transition': 'transform 0s'
        });
    });
});

function refreshAnimation($wizard, index) {
    total_steps = $wizard.find('li').length;
    move_distance = $wizard.width() / total_steps;
    step_width = move_distance;
    move_distance *= index;

    $current = index + 1;

    if ($current == 1) {
        move_distance -= 8;
    } else if ($current == total_steps) {
        move_distance += 8;
    }

    $wizard.find('.moving-tab').css('width', step_width);
    $('.moving-tab').css({
        'transform': 'translate3d(' + move_distance + 'px, 0, 0)',
        'transition': 'all 0.5s cubic-bezier(0.29, 1.42, 0.79, 1)'

    });
}

materialDesign = {

    checkScrollForTransparentNavbar: debounce(function () {
        if ($(document).scrollTop() > 260) {
            if (transparent) {
                transparent = false;
                $('.navbar-color-on-scroll').removeClass('navbar-transparent');
            }
        } else {
            if (!transparent) {
                transparent = true;
                $('.navbar-color-on-scroll').addClass('navbar-transparent');
            }
        }
    }, 17)

}

function debounce(func, wait, immediate) {
    var timeout;
    return function () {
        var context = this, args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            timeout = null;
            if (!immediate) func.apply(context, args);
        }, wait);
        if (immediate && !timeout) func.apply(context, args);
    };
};
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        //if (this.name == "AccountWith" || this.name == "CreditCardWith") { } else { }
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};
function formDataToJSON($formElement, isfinish) {

    //var formData = new FormData(formElement),
    //    convertedJSON = {};

    //formData.forEach(function (value, key) {
    //    convertedJSON[key] = value;
    //});
    var convertedJSON = JSON.stringify($formElement.serializeObject())
    var FormActionURL = $("#baseURL").text() + "/Loan/savestep";
    var Paramerter = {
        convertedJSON: convertedJSON,
        isfinish: isfinish,
    }
    return $.ajax({
        type: "POST",
        url: FormActionURL,
        cache: false,
        //async: false,
        data: Paramerter,
        success: function (data) {
            //debugger
            if (isfinish == 0)
                setCookie("user_id_Loan", data, 12);
            else if (isfinish == 1) {
                eraseCookie("user_id_Loan");
                $("#Id").val(0);
                window.location.href = "http://merimudra.com";
            }
            // $("#htmlListOfProduct").html(data);
            // alert(data);
        },
        error: function () {

        }
    });
    //return convertedJSON;
}
$(document).on({
    ajaxStart: function () {
        $(".btn-next").val("Loading..");
        $(".btn-next").attr("disabled", true);
        $(".btn-finish").val("Loading..");
        $(".btn-finish").attr("disabled", true);
    },
    ajaxComplete: function () {
        $(".btn-next").val("Next");
        $(".btn-next").removeAttr("disabled");
        $(".btn-finish").val("Finish");
        $(".btn-finish").removeAttr("disabled");
    }
})
