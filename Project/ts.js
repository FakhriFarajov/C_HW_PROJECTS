var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g = Object.create((typeof Iterator === "function" ? Iterator : Object).prototype);
    return g.next = verb(0), g["throw"] = verb(1), g["return"] = verb(2), typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var _a, _b, _c;
var _this = this;
var loadingAnim = document.getElementById("Loading");
var list = [];
function getApi() {
    return __awaiter(this, void 0, void 0, function () {
        var response, json, error_1;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 3, , 4]);
                    return [4 /*yield*/, fetch('api.json')];
                case 1:
                    response = _a.sent();
                    return [4 /*yield*/, response.json()];
                case 2:
                    json = _a.sent();
                    return [2 /*return*/, json.api];
                case 3:
                    error_1 = _a.sent();
                    console.error("Error loading API key from api.json:", error_1);
                    if (document.getElementById("headlinesContainer")) { // Assuming you have this ID for the main content area
                        document.getElementById("headlinesContainer").innerHTML = "<div>Error loading API configuration. News cannot be displayed.</div>";
                    }
                    return [3 /*break*/, 4];
                case 4: return [2 /*return*/];
            }
        });
    });
}
// --- getHeadLines function (corrected URL construction) ---
function getHeadLines(baseUrl) {
    return __awaiter(this, void 0, void 0, function () {
        var url, _a, _b, response, data, errorDetails, headlinesContainer, error_2;
        return __generator(this, function (_c) {
            switch (_c.label) {
                case 0: return [4 /*yield*/, getApi()];
                case 1:
                    // --- IMPORTANT: Check if API key is loaded before making the fetch call ---
                    if (!(_c.sent())) {
                        console.error("API Key not loaded yet. Cannot fetch headlines.");
                        if (loadingAnim)
                            loadingAnim.style.display = "none";
                        // Optionally display a message to the user that the API key isn't ready
                        return [2 /*return*/];
                    }
                    _c.label = 2;
                case 2:
                    _c.trys.push([2, 6, , 7]);
                    if (loadingAnim)
                        loadingAnim.style.display = "flex";
                    _b = (_a = "".concat(baseUrl, "&apiKey=")).concat;
                    return [4 /*yield*/, getApi()];
                case 3:
                    url = _b.apply(_a, [_c.sent()]);
                    return [4 /*yield*/, fetch(url)];
                case 4:
                    response = _c.sent();
                    return [4 /*yield*/, response.json()];
                case 5:
                    data = _c.sent();
                    if (!response.ok) {
                        errorDetails = (data === null || data === void 0 ? void 0 : data.message) || response.statusText;
                        throw new Error("News API Error: ".concat(response.status, " - ").concat(errorDetails));
                    }
                    if (loadingAnim)
                        loadingAnim.style.display = "none";
                    headlinesContainer = document.getElementById("headLines");
                    if (headlinesContainer) {
                        headlinesContainer.innerHTML = "";
                        if (data.articles && data.articles.length > 0) {
                            list = data.articles;
                            currentPage = 1; // Reset to first page after fetching
                            renderNews();
                        }
                        else {
                            list = [];
                            headlinesContainer.innerHTML = "<div>No headlines found.</div>";
                        }
                    }
                    return [3 /*break*/, 7];
                case 6:
                    error_2 = _c.sent();
                    if (loadingAnim)
                        loadingAnim.style.display = "none";
                    console.error("Headline fetch error:", error_2);
                    list = []; // Clear list on error
                    if (document.getElementById("headLines")) {
                        document.getElementById("headLines").innerHTML = "<div>Error fetching headlines: ".concat(error_2.message, ". Please try again later.</div>");
                    }
                    return [3 /*break*/, 7];
                case 7: return [2 /*return*/];
            }
        });
    });
}
var currentPage = 1;
var itemsPerPage = 10;
var headLines = document.getElementById("headLines");
var pageInfo = document.getElementById("CurrPage");
var prevBtn = document.getElementById("Prev");
var nextBtn = document.getElementById("Next");
function renderNews() {
    if (!list || !Array.isArray(list) || list.length === 0) {
        if (headLines)
            headLines.innerHTML = "<div>No headlines found.</div>";
        if (pageInfo)
            pageInfo.textContent = "";
        return;
    }
    if (headLines)
        headLines.innerHTML = "";
    var start = (currentPage - 1) * itemsPerPage;
    var end = start + itemsPerPage;
    var forecastPage = list.slice(start, end);
    var headlinesContainer = document.getElementById("headLines");
    if (headlinesContainer)
        forecastPage.forEach(function (article) {
            var _a;
            var item = document.createElement("a");
            item.className = "HeadLineItem";
            item.href = article.url || "#";
            item.target = "_blank";
            item.rel = "noopener noreferrer"; // Security best practice
            item.innerHTML = "\n                <img class=\"ImgDescription\" src=\"".concat(article.urlToImage ? article.urlToImage : "Img/Gemini_Generated_Image_swgtsqswgtsqswgt.png", "\" alt=\"\">\n                <div class=\"Descrioption\">\n                    <p class=\"Title\">").concat(article.title || "No Title", "</p>\n                    <p class=\"Source\">").concat(((_a = article.source) === null || _a === void 0 ? void 0 : _a.name) || "Unknown Source", "</p>\n                    <p class=\"Date\">").concat(article.publishedAt ? new Date(article.publishedAt).toLocaleDateString() : "", "</p>\n                </div>\n            ");
            headlinesContainer.appendChild(item);
        });
    var totalPages = Math.ceil(list.length / itemsPerPage);
    if (pageInfo)
        pageInfo.textContent = "Page ".concat(currentPage, " of ").concat(totalPages);
}
if (prevBtn)
    prevBtn.addEventListener("click", function () {
        if (currentPage > 1) {
            currentPage--;
            renderNews();
        }
    });
if (nextBtn)
    nextBtn.addEventListener("click", function () {
        var totalPages = Math.ceil(list.length / itemsPerPage);
        if (currentPage < totalPages) {
            currentPage++;
            renderNews();
        }
    });
document.addEventListener("DOMContentLoaded", function () { return __awaiter(_this, void 0, void 0, function () {
    return __generator(this, function (_a) {
        switch (_a.label) {
            case 0: return [4 /*yield*/, getApi()];
            case 1:
                if (!!(_a.sent())) return [3 /*break*/, 3];
                return [4 /*yield*/, new Promise(function (resolve) { return setTimeout(resolve, 50); })];
            case 2:
                _a.sent(); // Wait a bit
                return [3 /*break*/, 0];
            case 3:
                console.log("Initial fetch triggered.");
                return [4 /*yield*/, getHeadLines("https://newsapi.org/v2/top-headlines?country=us")];
            case 4:
                _a.sent(); // getHeadLines will append the key
                return [2 /*return*/];
        }
    });
}); });
var categoryBaseUrls = {
    Politics: "https://newsapi.org/v2/everything?q=Politics&sortBy=popularity",
    Economics: "https://newsapi.org/v2/everything?q=Economics&sortBy=popularity",
    Business: "https://newsapi.org/v2/everything?q=Business&sortBy=popularity",
    Technology: "https://newsapi.org/v2/everything?q=Technology&sortBy=popularity",
    Sports: "https://newsapi.org/v2/everything?q=Sports&sortBy=popularity",
};
Object.keys(categoryBaseUrls).forEach(function (category) {
    var _a;
    (_a = document.getElementById(category)) === null || _a === void 0 ? void 0 : _a.addEventListener("click", function () { return __awaiter(_this, void 0, void 0, function () {
        var headLinesTitle;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    headLinesTitle = document.getElementById("HeadLinesTitle");
                    if (headLinesTitle)
                        headLinesTitle.innerHTML = category;
                    return [4 /*yield*/, getHeadLines(categoryBaseUrls[category])];
                case 1:
                    _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
});
(_a = document.getElementById("InputImg")) === null || _a === void 0 ? void 0 : _a.addEventListener("click", function () { return __awaiter(_this, void 0, void 0, function () {
    var inputElement, value, _a, _b, _c, headLinesTitle;
    return __generator(this, function (_d) {
        switch (_d.label) {
            case 0:
                inputElement = document.getElementById("Input");
                value = "";
                if (inputElement.value) {
                    value = inputElement.value;
                    inputElement.value = "";
                }
                else {
                    return [2 /*return*/];
                }
                value = value.trim();
                _a = getHeadLines;
                _c = (_b = "https://newsapi.org/v2/everything?q=".concat(value, "&apiKey=")).concat;
                return [4 /*yield*/, getApi()];
            case 1: return [4 /*yield*/, _a.apply(void 0, [_c.apply(_b, [_d.sent()])])];
            case 2:
                _d.sent();
                headLinesTitle = document.getElementById("HeadLinesTitle");
                if (headLinesTitle) {
                    headLinesTitle.innerHTML = value;
                }
                return [2 /*return*/];
        }
    });
}); });
(_b = document.getElementById("LogoImg")) === null || _b === void 0 ? void 0 : _b.addEventListener("click", function () { return __awaiter(_this, void 0, void 0, function () {
    var headLinesTitle;
    return __generator(this, function (_a) {
        switch (_a.label) {
            case 0: return [4 /*yield*/, getHeadLines("https://newsapi.org/v2/top-headlines?country=us")];
            case 1:
                _a.sent();
                headLinesTitle = document.getElementById("HeadLinesTitle");
                if (headLinesTitle)
                    headLinesTitle.innerHTML = "HeadLines";
                return [2 /*return*/];
        }
    });
}); });
(_c = document.getElementById("Input")) === null || _c === void 0 ? void 0 : _c.addEventListener("keypress", function (e) { return __awaiter(_this, void 0, void 0, function () {
    var inputElement, value, _a, _b, _c, headLinesTitle;
    return __generator(this, function (_d) {
        switch (_d.label) {
            case 0:
                if (e.key != "Enter")
                    return [2 /*return*/];
                inputElement = document.getElementById("Input");
                value = "";
                if (inputElement.value) {
                    value = inputElement.value;
                    inputElement.value = "";
                }
                else
                    return [2 /*return*/];
                value = value.trim();
                _a = getHeadLines;
                _c = (_b = "https://newsapi.org/v2/everything?q=".concat(value, "&apiKey=")).concat;
                return [4 /*yield*/, getApi()];
            case 1: return [4 /*yield*/, _a.apply(void 0, [_c.apply(_b, [_d.sent()])])];
            case 2:
                _d.sent();
                headLinesTitle = document.getElementById("HeadLinesTitle");
                if (headLinesTitle) {
                    headLinesTitle.innerHTML = value;
                }
                return [2 /*return*/];
        }
    });
}); });
