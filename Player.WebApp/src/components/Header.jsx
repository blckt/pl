import React from 'react';
import { AppBar } from 'material-ui';

class Header extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (<AppBar title="Playlist"></AppBar>)
    }
}


module.exports = Header;
