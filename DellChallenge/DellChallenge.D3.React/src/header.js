import React, { Component } from "react";
import logo from "./logo.svg";

let linkData = [
  { title: "Home", url: "/" },
  { title: "Privacy", url: "/privacy" },
  { title: "Products", url: "/products" },
  { title: "NewProduct", url: "/newproduct" },
];

const LinkList = (props) => {
  return (
    <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
      <div className="container">
        <a className="navbar-brand" href="/"><img width="50" src={logo} className="App-logo" alt="logo" />DellChallenge.D3.React</a>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
          <ul className="navbar-nav flex-grow-1">
            {props.links.map((link) => 
              <li key={link.url} className="nav-item">
                <a className="nav-link text-dark" href={link.url} >{link.title} </a>
              </li>
            )}
          </ul>
        </div>
      </div>
    </nav>
  )
}

class Header extends Component {
  render() {
    return (
      <LinkList links={linkData} />
    );
  }
}
export default Header;
