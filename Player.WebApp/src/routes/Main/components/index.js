import React from 'react'

const component = (props) => {
    return (
        <div>
            <h1>It Works!</h1>
            <p>This React project just works including <span>module</span> local styles.</p>
            <p>Global bootstrap css import works too as you can see on the following button.</p>
            <p><a href="/" className="btn btn-primary btn-lg">Enjoy!</a></p>
        </div>
    )
}
module.exports = component;