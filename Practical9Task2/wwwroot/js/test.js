let ShowResult;
let AddText = document.getElementById("ShowText");
//Print text
function PrintText() {
    AddText.innerHTML = "Hello World";
    ShowResult = AddText.innerHTML;
}
//Bold text
function BoldText() {
    AddText.innerHTML = ShowResult.bold(); 
    ShowResult = AddText.innerHTML;
}
//Italic text
function ItalicText() {
    AddText.innerHTML = ShowResult.italics(); 
    ShowResult = AddText.innerHTML;
}
//Underline text
function UnderlineText() {
    AddText.innerHTML = "<u>" + ShowResult + "</u>";
    ShowResult = AddText.innerHTML;
}