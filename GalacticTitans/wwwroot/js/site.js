// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//    document.addEventListener("DOMContentLoaded", function () {

//    const btn = document.getElementById("bgm-toggle");
//    const iframe = document.getElementById("audio-frame");

//    let audio = null;

//    // Wait for iframe to load to access its content
//    iframe.onload = function () {
//        try {
//        audio = iframe.contentWindow.document.getElementById("bgAudio");

//    if (!audio) {
//        console.error("bgAudio element NOT found inside iframe.");
//            } else {
//        console.log("bgAudio loaded and ready.");
//            }

//        } catch (err) {
//        console.error("Error accessing iframe:", err);
//        }
//    };

//    btn.addEventListener("click", function () {

//        if (!audio) {
//        console.warn("Audio not ready yet. Iframe might still be loading.");
//    return;
//        }

//    // Toggle play / stop
//    if (audio.paused) {
//        audio.muted = false;   // required to bypass autoplay block
//            audio.play().catch(err => console.error("Play failed:", err));
//    btn.textContent = "Stop Music";
//        } else {
//        audio.pause();
//    btn.textContent = "Play Music";
//        }
//    });

//});

//document.getElementById("start-music").addEventListener("click", function () {
//    window.open(
//        '@Url.Action("AudioPlayer", "Audio")',
//        '_blank',
//        'width=1,height=1,left=-1000,top=-1000'
//    );
//});