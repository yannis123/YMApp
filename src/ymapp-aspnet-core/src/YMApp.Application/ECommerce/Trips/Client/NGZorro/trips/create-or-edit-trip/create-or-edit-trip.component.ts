
import { Component, OnInit, Injector, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { CreateOrUpdateTripInput,TripEditDto, TripServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-trip',
  templateUrl: './create-or-edit-trip.component.html',
  styleUrls:[
	'create-or-edit-trip.component.less'
  ],
})

export class CreateOrEditTripComponent
  extends ModalComponentBase
    implements OnInit {
    /**
    * 编辑时DTO的id
    */
    id: any ;

	  entity: TripEditDto=new TripEditDto();

    /**
    * 初始化的构造函数
    */
    constructor(
		injector: Injector,
		private _tripService: TripServiceProxy
	) {
		super(injector);
    }

    ngOnInit() :void{
		this.init();
    }


    /**
    * 初始化方法
    */
    init(): void {
		this._tripService.getForEdit(this.id).subscribe(result => {
			this.entity = result.trip;
		});
    }

    /**
    * 保存方法,提交form表单
    */
    submitForm(): void {
		const input = new CreateOrUpdateTripInput();
		input.trip = this.entity;

		this.saving = true;

		this._tripService.createOrUpdate(input)
		.finally(() => (this.saving = false))
		.subscribe(() => {
			this.notify.success(this.l('SavedSuccessfully'));
			this.success(true);
		});
    }
}
