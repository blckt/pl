import store from './createStore';
import { pingAuth } from '../actions/usersActions';
export default function (nextState, replaceState) {
    const state = store.getState();
    const isLoggedIn = !!state.token;
    const isChecked = !state.pinged;
    if (!isLoggedIn) {
        replaceState({ nextPathname: nextState.location.pathname, pathname: '/auth' });
    }
    // if (isLoggedIn && isChecked)
    //     store.dispatch(pingAuth(state));
}