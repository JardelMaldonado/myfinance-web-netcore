/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.cshtml",
    "./Pages/**/*.cshtml",
    "./wwwroot/**/*.html",
    "./**/*.cshtml" // Isso garante que ele pegue qualquer arquivo na raiz
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}