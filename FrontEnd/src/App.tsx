import "./App.css"
// import { Counter } from "./features/counter/Counter"
// import { Quotes } from "./features/quotes/Quotes"
import logo from "./logo.svg"

console.log(fetch(`/api/test`).then((response)=>response.json()).then(data => data))

const App = () => {
  return (
    <div className="App">
      <h1 className="App-title">
        Hooper Analytics
      </h1>
      <a href="https://github.com/Nemurs/HooperAnalytics">
        <img src={logo} className="App-logo" alt="logo" />
      </a>
      <h2 className="under-construction">
        🚧 Site Under Construction 🚧
      </h2>
      {/* <header className="App-header">
        <Counter />
        <Quotes />
        <span>
          <span>Learn </span>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            React
          </a>
          <span>, </span>
          <a
            className="App-link"
            href="https://redux.js.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Redux
          </a>
          <span>, </span>
          <a
            className="App-link"
            href="https://redux-toolkit.js.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Redux Toolkit
          </a>
          <span>, </span>
          <a
            className="App-link"
            href="https://react-redux.js.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            React Redux
          </a>
          ,<span> and </span>
          <a
            className="App-link"
            href="https://reselect.js.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Reselect
          </a>
        </span>
      </header> */}
    </div>
  )
}

export default App
