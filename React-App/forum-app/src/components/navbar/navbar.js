import React from 'react';
import './navbar.css';
import { Link } from 'react-router-dom';

const NavBar = () => {
    return (
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <Link className="navbar-brand" to="/">ForumApp</Link>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
  
            <form class="form-inline my-4 my-lg-0 pull-right">
                <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" />
                <button class="btn btn-outline-primary my-2 my-sm-0" type="submit">Search</button>
            </form>
  </nav>)
}

export default NavBar;