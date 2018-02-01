import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

import './navbar.css';
import { searchByTitle } from '../../actions/index';

class NavBar extends Component {
    constructor(props){
        super(props);

        this.state = {
            searchTitle: ''
        }

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(event) {
        event.preventDefault();

        this.props.searchByTitle(this.state.searchTitle);
        this.props.history.push("/");
    }

    onChange = (event) => this.setState({  searchTitle: event.target.value})

    render() {
        return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <Link className="navbar-brand" to="/">ForumApp</Link>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
            </button>
  
            <form className="form-inline my-4 my-lg-0 pull-right" onSubmit={this.onSubmit}>
                <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" onChange={this.onChange} value={this.state.searchTitle}/>
                <button className="btn btn-outline-primary my-2 my-sm-0" type="submit">Search</button>
            </form>
  </nav>)
    }
}

export default withRouter(connect(null, { searchByTitle })(NavBar));