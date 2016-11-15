module.exports = {
    path: '/auth',
    getComponent(nextState, cb) {
        require.ensure([], (require) => cb(null, require('./AuthPage')));
    }
}