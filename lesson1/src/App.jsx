import './App.css';
import CityInfoTask1 from "./components/Task1/CityInfo"
import CityInfoTask2 from "./components/Task2/CityInfo"
import BookInfo from "./components/Task3/Book"
import BookInfo1 from "./components/Task4/Book"
function App() {
  return (
    <div className="App">
      <h1>Task1</h1>
      <CityInfoTask1/>
      <br />
      <h1>Task2</h1>
      <CityInfoTask2/>
      <h1>Task3</h1>
      <BookInfo/>
      <h1>Task4</h1>
      <BookInfo1></BookInfo1>
    </div>
  );
}

export default App;