

(function () {
    $('.form__file"').each(function () {
        let $input = $(this),
            $label = $input.next('.js-labelFile'),
            labelVal = $label.html();

        $input.on('change', function (element) {
            let fileName = '';
            if (element.target.value) fileName = element.target.value.split('\\').pop();
            fileName ? $label.addClass('has-file').find('.js-fileName').html(fileName) : $label.removeClass('has-file').html(labelVal);
        });
    });
})();
AOS.init();
$('.single-item').slick();
$('.one-time').slick({
    dots: true
});
const swiper = new Swiper('.swiper', {
    // Optional parameters
    direction: 'horizontal',
    loop: true,
    // If we need pagination
    pagination: {
        el: '.swiper-pagination',
    },
    // Navigation arrows
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    // And if we need scrollbar
    scrollbar: {
        el: '.swiper-scrollbar',
    },
    slidesPerView: 3,
    spaceBetween: 60,
    centeredSlides: true,
    slidesPerView: 'auto',
});
const body = document.querySelector('.js-body');
const nav = document.querySelector('.js-nav');
const social = document.querySelector('.js-social');
const burger = document.querySelector('.js-burger');

burger.addEventListener('click', () => {
    burger.classList.toggle('burger--active');
    nav.classList.toggle('header__nav--active');
    social.classList.toggle('header__social--active');
    body.classList.toggle('body--lock');
});
