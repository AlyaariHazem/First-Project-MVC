(function($) {
    "use strict";

    // Removed sidebar-related initializations and event handlers

    var $slimScrolls = $('.slimscroll');

    // Initialize slimScroll if elements with class 'slimscroll' exist
    if ($slimScrolls.length > 0) {
        $slimScrolls.slimScroll({
            height: 'auto',
            width: '100%',
            position: 'right',
            size: '7px',
            color: '#ccc',
            allowPageScroll: false,
            wheelStep: 10,
            touchScrollStep: 100
        });

        // Function to adjust slimScroll height based on window size
        var adjustSlimScrollHeight = function() {
            var rHeight = $(window).height() - 60;
            $slimScrolls.height(rHeight);
            $('.sidebar .slimScrollDiv').height(rHeight);
        };

        // Initial adjustment
        adjustSlimScrollHeight();

        // Adjust on window resize
        $(window).resize(adjustSlimScrollHeight);
    }

    // Other unrelated functionalities remain intact

    // Toggle password visibility
    if ($('.toggle-password').length > 0) {
        $(document).on('click', '.toggle-password', function() {
            $(this).toggleClass("fa-eye fa-eye-slash");
            var input = $(".pass-input");
            if (input.attr("type") == "password") {
                input.attr("type", "text");
            } else {
                input.attr("type", "password");
            }
        });
    }

    // Check all mails
    $(document).on('click', '#check_all', function() {
        $('.checkmail').click();
        return false;
    });

    // Toggle 'checked' class on individual mails
    if ($('.checkmail').length > 0) {
        $('.checkmail').each(function() {
            $(this).on('click', function() {
                if ($(this).closest('tr').hasClass('checked')) {
                    $(this).closest('tr').removeClass('checked');
                } else {
                    $(this).closest('tr').addClass('checked');
                }
            });
        });
    }

    // Checkbox all functionality
    if ($('.checkbox-all').length > 0) {
        $('.checkbox-all').click(function() {
            $('.checkmail').click();
        });
    }

    // Toggle mail importance
    $(document).on('click', '.mail-important', function() {
        $(this).find('i.fa').toggleClass('fa-star fa-star-o');
    });

    // Toggle mini-sidebar
    $(document).on('click', '#toggle_btn', function() {
        if ($('body').hasClass('mini-sidebar')) {
            $('body').removeClass('mini-sidebar');
            $('.subdrop + ul').slideDown();
        } else {
            $('body').addClass('mini-sidebar');
            $('.subdrop + ul').slideUp();
        }
    });

    // Expand menu on hover when mini-sidebar is active
    $(document).on('mouseover', function(e) {
        e.stopPropagation();
        if ($('body').hasClass('mini-sidebar') && $('#toggle_btn').is(':visible')) {
            var targ = $(e.target).closest('.sidebar').length;
            if (targ) {
                $('body').addClass('expand-menu');
                $('.subdrop + ul').slideDown();
            } else {
                $('body').removeClass('expand-menu');
                $('.subdrop + ul').slideUp();
            }
            return false;
        }
    });

    // Toggle filter search inputs
    $(document).on('click', '#filter_search', function() {
        $('#filter_inputs').slideToggle("slow");
    });

    // File upload previews
    if ($('.custom-file-container').length > 0) {
        var firstUpload = new FileUploadWithPreview('myFirstImage');
        var secondUpload = new FileUploadWithPreview('mySecondImage');
    }

    // Clipboard functionality
    if ($('.clipboard').length > 0) {
        var clipboard = new Clipboard('.btn');
    }

    // Initialize Summernote editor
    if ($('#summernote').length > 0) {
        $('#summernote').summernote({
            height: 300,
            minHeight: null,
            maxHeight: null,
            focus: true
        });
    }

    // Initialize Bootstrap tooltips
    if ($('[data-bs-toggle="tooltip"]').length > 0) {
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        var tooltipList = tooltipTriggerList.map(function(tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }

    // Initialize Bootstrap popovers
    if ($('.popover-list').length > 0) {
        var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
        var popoverList = popoverTriggerList.map(function(popoverTriggerEl) {
            return new bootstrap.Popover(popoverTriggerEl);
        });
    }

    if ($('[data-toggle="popover"]').length > 0) {
        $('[data-toggle="popover"]').popover();
    }

    // Initialize counterUp
    if ($('.counter').length > 0) {
        $('.counter').counterUp({
            delay: 20,
            time: 2000
        });
    }

    // Initialize countdown timers
    if ($('#timer-countdown').length > 0) {
        $('#timer-countdown').countdown({
            from: 180,
            to: 0,
            movingUnit: 1000,
            timerEnd: undefined,
            outputPattern: '$day Day $hour : $minute : $second'
        });
    }

    if ($('#timer-countup').length > 0) {
        $('#timer-countup').countdown({
            from: 0,
            to: 180
        });
    }

    if ($('#timer-countinbetween').length > 0) {
        $('#timer-countinbetween').countdown({
            from: 30,
            to: 20
        });
    }

    if ($('#timer-countercallback').length > 0) {
        $('#timer-countercallback').countdown({
            from: 10,
            to: 0,
            timerEnd: function() {
                this.css({ 'text-decoration': 'line-through' }).animate({ 'opacity': .5 }, 500);
            }
        });
    }

    if ($('#timer-outputpattern').length > 0) {
        $('#timer-outputpattern').countdown({
            outputPattern: '$day Days $hour Hour $minute Min $second Sec..',
            from: 60 * 60 * 24 * 3
        });
    }

    // Initialize yearpicker
    if ($('.yearpicker').length > 0) {
        $(".yearpicker").yearpicker({
            year: 2020,
            startYear: 1900,
            endYear: 2100
        });
    }

    // Regenerate password functionality
    $(document).on('click', '#regenerate_password', function() {
        var password = generatePassword();
        $("#new_password").val(password);
    });

    function generatePassword() {
        var length = 8;
        var charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var retVal = "";
        for (var i = 0, n = charset.length; i < length; ++i) {
            retVal += charset.charAt(Math.floor(Math.random() * n));
        }
        return retVal;
    }
    
    /* Removed developer tools blocking code By Hazem Alyaari
    /*
    $(document).bind("contextmenu", function(e) {
        e.preventDefault();
    });
  
    $(document).keydown(function(e) {
        if (e.keyCode == 123) {
            return false;
        }
        if (e.ctrlKey && e.shiftKey && e.keyCode == 'I'.charCodeAt(0)) {
            return false;
        }
        if (e.ctrlKey && e.shiftKey && e.keyCode == 'C'.charCodeAt(0)) {
            return false;
        }
        if (e.ctrlKey && e.shiftKey && e.keyCode == 'J'.charCodeAt(0)) {
            return false;
        }
        if (e.ctrlKey && e.keyCode == 'U'.charCodeAt(0)) {
            return false;
        }
    });
    */

})(jQuery);
