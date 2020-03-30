(function($, window, document, undefined){
    const rtl = document.getElementsByTagName('html')[0].getAttribute('dir') === 'rtl';
    
    const win = $(window);
    const allMods = $(".feature");

    allMods.each(function(i, e) {
        const el = $(e);
        if (el.visible(true)) {
            el.addClass("already-visible");
        }
    });

    win.scroll(function(event) {
        allMods.each(function(i, e) {
            const el = $(e);
            if (el.visible(true)) {
                el.addClass("come-in");
            }
        });

    });

    $('.your-work .owl-carousel').owlCarousel({
        rtl:rtl,
        loop:true,
        margin:10,
        nav:true,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:3
            },
            1000:{
                items:5
            }
        }
    });
})(jQuery, window, document);