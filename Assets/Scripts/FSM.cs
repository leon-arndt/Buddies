﻿public class FSM<T> {
	private T Owner;
	private IFSMState<T> CurrentState;

    public void Configure(T owner, IFSMState<T> initialState) {
		Owner = owner;
		ChangeState(initialState);
	}

	public void Update() {
        if (CurrentState != null) { //if the enemy is in a state
            CurrentState.Reason(Owner);
            CurrentState.Update(Owner);
        }
	}

    public void ChangeState(IFSMState<T> newState) {
		if (CurrentState != null)
			CurrentState.Exit(Owner);
		CurrentState = newState;
		if (CurrentState != null)
			CurrentState.Enter(Owner);
	}
};
